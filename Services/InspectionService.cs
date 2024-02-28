using System.Net.Mail;
using ApiProject.Data;
using ApiProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class InspectionService(ApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        public async Task<InspectionModel> GetInspectionbyId(Guid id)
        {
            InspectionModel inspection = await dbContext.Inspection
                .Where(i => i.Id == id)
                .Include(i => i.Patient)
                .Include(i => i.Doctor)
                .Include(i => i.Diagnoses)
                .Include(i => i.Consultations)
                    .ThenInclude(c => c.Speciality)
                .Include(i => i.Consultations)
                    .ThenInclude(c => c.RootComment)
                        .ThenInclude(rc => rc.Author)
                            .ThenInclude(a => a.Speciality)
                .FirstOrDefaultAsync();
            return inspection;
        }
        public async Task EditInspection(Guid id, InspectionEditModel edited)
        {
            InspectionModel inspectionModel =
                await dbContext.Inspection
                    .Include(i => i.Diagnoses)
                    .FirstOrDefaultAsync(i => i.Id == id);
            if (inspectionModel == null)
            {
                throw new ArgumentException("Inspection not found");
            }
            mapper.Map(edited, inspectionModel);
            if (inspectionModel.DoctorId.ToString() != httpContextAccessor.HttpContext.User.FindFirst("UserId").Value)
            {
                throw new UnauthorizedAccessException();
            }
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task<List<InspectionPreviewModel>> FindByBaseInspection(Guid id)
        {
            List<InspectionPreviewModel> ipm = dbContext.Inspection
                .Where(i => i.BaseInspectionId == id)
                .Include(i => i.Diagnoses)
                .Select(i => mapper.Map<InspectionPreviewModel>(i))
                .ToList();
            return ipm;
        }
    }
}