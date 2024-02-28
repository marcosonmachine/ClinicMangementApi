using ApiProject.Data;
using ApiProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class PatientService
    (
        ApplicationDbContext dbContext,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    )
    {
        public async Task<Guid?> CreatePatient(PatientCreateModel patient)
        {
            try
            {
                PatientModel patientModel = mapper.Map<PatientModel>(patient);

                dbContext.Patient.Add(patientModel);
                dbContext.SaveChanges();
                return patientModel.Id;
            }
            catch (Exception e)
            {
                return Guid.Empty;
            }
        }
        public async Task<PatientModel?> GetPatientById(Guid id)
        {
            return await dbContext.Patient.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<PatientPagedListModel> GetPatientsList
        (
            string name,
            List<Conclusion> conclusions,
            PatientSorting sorting,
            bool? scheduledVisits,
            bool? onlyMine,
            int? page,
            int? size
        )
        {
            IQueryable<PatientModel> query = dbContext.Patient.Include(p => p.Inspections).ThenInclude(i => i.Diagnoses);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            if (conclusions != null && conclusions.Any())
            {
                query = query.Where(p => p.Inspections.Any(i => conclusions.Contains(i.Conclusion)));
            }

            if (scheduledVisits.HasValue)
            {
                if (scheduledVisits.Value)
                {
                    query = query.Where(p => p.Inspections.Any(i => i.NextVisitDate.HasValue && i.NextVisitDate > DateTime.UtcNow));
                }
                else
                {
                    query = query.Where(p => !p.Inspections.Any(i => i.NextVisitDate.HasValue && i.NextVisitDate > DateTime.UtcNow));
                }
            }

            if (onlyMine.HasValue && onlyMine.Value)
            {
                // Assuming you have a way to identify the current user or doctor
                query = query.Where(p => p.Inspections.Any(
                    e => e.Doctor.Id.ToString() == httpContextAccessor.HttpContext.User.FindFirst("UserId").Value
                ));
            }

            switch (sorting)
            {
                case PatientSorting.NameAscEnum:
                    query = query.OrderBy(p => p.Name);
                    break;
                case PatientSorting.NameDescEnum:
                    query = query.OrderByDescending(p => p.Name);
                    break;
                case PatientSorting.InspectionAscEnum:
                    query = query.OrderBy(p => p.Inspections);
                    break;
                case PatientSorting.InspectionDescEnum:
                    query = query.OrderByDescending(p => p.Inspections);
                    break;
                case PatientSorting.CreateAscEnum:
                    query = query.OrderBy(p => p.CreateTime);
                    break;
                case PatientSorting.CreateDescEnum:
                    query = query.OrderByDescending(p => p.CreateTime);
                    break;
                default:
                    break;
            }

            int pageNumber = page ?? 1;
            int pageSize = size ?? 10;
            PaginatedModel<PatientModel> pList = await ApplicationDbContext.GetPageList(query, pageNumber, pageSize);
            return mapper.Map<PatientPagedListModel>(pList);
        }

        public async Task<InspectionPagedListModel> GetPatientInspections
        (
            Guid id,
            bool grouped,
            int page,
            int size
        )
        {
            PaginatedModel<InspectionModel> pList;

            if (grouped == true)
            {
                var collapsed = dbContext.Inspection
                    .Where(i => i.PatientId == id && i.BaseInspectionId != null)
                    .Distinct()
                    .Include(i => i.Diagnoses)
                    .Include(i => i.Doctor)
                    .Include(i => i.Patient);
                pList = await ApplicationDbContext.GetPageList(collapsed, page, size);
            }
            else
            {
                var collapsed = dbContext.Inspection
                    .Where(i => i.PatientId == id)
                    .Distinct()
                    .Include(i => i.Diagnoses)
                    .Include(i => i.Doctor)
                    .Include(i => i.Patient);

                pList = await ApplicationDbContext.GetPageList(collapsed, page, size);
            }
            // Didn't wanted to write more mapping
            // Also dumb
            PaginatedModel<InspectionPreviewModel> x = mapper.Map<PaginatedModel<InspectionPreviewModel>>(pList);
            InspectionPagedListModel y = mapper.Map<InspectionPagedListModel>(x);
            return y;
        }

        public async Task<List<InspectionShortModel>> GetShortInspectionsList(Guid id, string diagnosisName)
        {
            List<InspectionShortModel> list = dbContext.Inspection
                .Where(i => i.PatientId == id && i.Diagnoses.Any(d => d.Name.Contains(diagnosisName)))
                .Include(i => i.Diagnoses)
                .Select(i => new InspectionShortModel
                {
                    Id = i.Id,
                    CreateTime = i.CreateTime,
                    Date = i.Date,
                    Diagnosis = i.Diagnoses.FirstOrDefault(d => d.Type == DiagnosisType.MainEnum)
                }).ToList();
            return list;
        }
        public async Task<Guid?> CreatePatientInspection(Guid id, InspectionCreateModel model)
        {
            if (model.Date == null || model.Date > DateTime.UtcNow)
            {
                throw new ArgumentException("Inspection date cannot be in the future.");
            }

            if (model.PreviousInspectionId.HasValue)
            {
                var previousInspection = await dbContext.Inspection.FindAsync(model.PreviousInspectionId.Value);
                if (previousInspection == null)
                {
                    throw new ArgumentException("Invalid previous inspection ID provided.");
                }

                if (model.Date <= previousInspection.Date)
                {
                    throw new ArgumentException("Inspection date cannot be earlier than the previous inspection.");
                }
            }

            if (!model.Diagnoses.Any(d => d.Type == DiagnosisType.MainEnum))
            {
                throw new ArgumentException("An inspection must have at least one 'Main' diagnosis.");
            }

            switch (model.Conclusion)
            {
                case Conclusion.DiseaseEnum:
                    if (!model.NextVisitDate.HasValue)
                    {
                        throw new ArgumentException("Next visit date must be specified for the 'Disease' conclusion.");
                    }
                    break;
                case Conclusion.DeathEnum:
                    // Check for existing "Death" conclusion for the patient (optional based on rule interpretation)
                    // if (dbContext.Inspection.Any(i => i.PatientId == id && i.Conclusion == Conclusion.Death))
                    // {
                    //     throw new ArgumentException("Patient already has an inspection with the 'Death' conclusion.");
                    // }
                    if (!model.DeathDate.HasValue)
                    {
                        throw new ArgumentException("Death date must be specified for the 'Death' conclusion.");
                    }
                    break;
                case Conclusion.RecoveryEnum:
                    break;
                default:
                    throw new ArgumentException("Invalid conclusion provided.");
            }

            if (model.Consultations.GroupBy(c => c.SpecialityId).Any(g => g.Count() > 1))
            {
                throw new ArgumentException("An inspection cannot have multiple consultations with the same physician specialty.");
            }

            InspectionModel inspectionModel;
            try
            {
                inspectionModel = mapper.Map<InspectionModel>(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            List<ConsultationCreateModel> consultations = model.Consultations;

            var specialityMap = await dbContext.Speciality.ToDictionaryAsync(s => s.Id, s => s);

            foreach (var consultation in consultations)
            {
                if (!specialityMap.ContainsKey(consultation.SpecialityId))
                {
                    throw new ArgumentException($"Invalid speciality ID: {consultation.SpecialityId} does not exist in the database.");
                }
           }

            inspectionModel.PatientId = id;
            await dbContext.Inspection.AddAsync(inspectionModel);
            await dbContext.SaveChangesAsync();

            return inspectionModel.Id;
        }
    }
}
