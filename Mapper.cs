using ApiProject.Data;
using ApiProject.Models;
using AutoMapper;
using Microsoft.Data.SqlClient;

namespace ApiProject.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            //Create models to Data Model
            CreateMap<DoctorRegisterModel, DoctorModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())) // Ignore Id property
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Speciality, opt => opt.Ignore()) // Not nullable
                .ForMember(dest => dest.SpecialityId, opt => opt.MapFrom(src => src.Speciality)); // Set Speciality Id

            CreateMap<InspectionCreateModel, InspectionModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => DateTime.UtcNow))
                // Needs httpCall, need changes for local validity
                // Also assuming auth works
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => httpContextAccessor.HttpContext.User.FindFirst("UserId").Value));
            CreateMap<DiagnosisCreateModel, DiagnosisModel>()
                // .ForMember(dest => dest.Id, 
                //     opt => opt.MapFrom(
                //         (src, dest) => (dest.Id == Guid.Empty || dest.Id == null) ? Guid.NewGuid() : dest.Id)
                //     )
                .ForMember(dest => dest.CreateTime, 
                    opt => opt.MapFrom(
                        (src, dest) => (dest.CreateTime == DateTime.MinValue || dest.CreateTime == null) ? DateTime.UtcNow : dest.CreateTime)
                    );
            CreateMap<ConsultationCreateModel, InspectionConsultationModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember
                (
                    dest => dest.RootComment,
                    opt => opt.Ignore()
                    // opt => opt.MapFrom(src => new List<InspectionCommentCreateModel>{src.Comment})
                );
            CreateMap<InspectionCommentCreateModel, InspectionCommentModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<InspectionCommentModel, CommentModel>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => src.ModifyTime));


            CreateMap<DoctorEditModel, DoctorModel>();
            CreateMap<SpecialityAddModel, SpecialityModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<PatientCreateModel, PatientModel>()
                 .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => DateTime.UtcNow))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                 .ForMember(dest => dest.Inspections, opt => opt.Ignore());

            CreateMap<InspectionModel, InspectionShortModel>()
                .ForMember(dest => dest.Diagnosis, opt => opt.MapFrom(src => src.Diagnoses.Where(d => d.Type == DiagnosisType.MainEnum).FirstOrDefault()));

            CreateMap<InspectionEditModel, InspectionModel>();

            CreateMap<InspectionModel, InspectionPreviewModel>()
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor.Name))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient.Name))
                .ForMember(dest => dest.Diagnosis, opt => opt.MapFrom(src => src.Diagnoses.Where(d => d.Type == DiagnosisType.MainEnum).FirstOrDefault()))
                .ForMember(dest => dest.PreviousId, opt => opt.MapFrom(src => src.PreviousInspectionId))
                .ForMember(dest => dest.HasChain, opt => opt.MapFrom(src => (src.BaseInspectionId == null) ? true : false))
                .ForMember(dest => dest.HasNested, opt => opt.MapFrom(src => (src.PreviousInspectionId == null) ? true : false));

            CreateMap<PaginatedModel<PatientModel>, PatientPagedListModel>()
                .ForMember(dest => dest.Patients, opt => opt.MapFrom(src => src.Entities));
            CreateMap<PaginatedModel<SpecialityModel>, SpecialtiesPagedListModel>()
                .ForMember(dest => dest.Specialties, opt => opt.MapFrom(src => src.Entities));
            CreateMap<PaginatedModel<InspectionModel>, PaginatedModel<InspectionPreviewModel>>();
            CreateMap<PaginatedModel<InspectionPreviewModel>, InspectionPagedListModel>()
                .ForMember(dest => dest.Inspections, opt => opt.MapFrom(src => src.Entities));


        }
    }
}
