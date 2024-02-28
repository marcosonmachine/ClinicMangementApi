using ApiProject.Data;
using ApiProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace ApiProject.Services
{
    public class ConsultationService(
        ApplicationDbContext dbContext,
        IMapper mapper,
        IHttpContextAccessor httpContext
    )
    {
        public async Task<InspectionPagedListModel> GetPatientInspections
                (
                    bool grouped,
                    int page,
                    int size
                )
        {
            Guid docId = Guid.Parse(httpContext.HttpContext.User.FindFirst("UserId").Value);
            PaginatedModel<InspectionModel> pList;

            if (grouped == true)
            {
                var collapsed = dbContext.Inspection
                    .Where(i => i.DoctorId == docId && i.BaseInspectionId != null)
                    .Distinct()
                    .Include(i => i.Diagnoses)
                    .Include(i => i.Doctor)
                    .Include(i => i.Patient);
                pList = await ApplicationDbContext.GetPageList(collapsed, page, size);
            }
            else
            {
                var collapsed = dbContext.Inspection
                    .Where(i => i.DoctorId == docId)
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
        public async Task<ConsultationModel> GetConsultations(Guid id)
        {
            ConsultationModel cml = await dbContext.Consultation
                .Where(c => c.Id == id)
                .Include(c => c.RootComment)
                    .ThenInclude(rc => rc.Parent)
                .Select(x => new ConsultationModel
                {
                    Id = x.Id,
                    CreateTime = x.CreateTime,
                    InspectionId = x.InspectionId,
                    SpecialityId = x.SpecialityId,
                    Comments = GetAllComments(x.RootComment)
                }).FirstOrDefaultAsync();
            return cml;
        }
        public List<CommentModel> GetAllComments(InspectionCommentModel rootComment)
        {
            var comments = new List<CommentModel>();
            if (rootComment != null)
            {
                var commentModel = mapper.Map<CommentModel>(rootComment);
                comments.Add(commentModel);

                comments.AddRange(GetAllComments(rootComment.Parent));
            }
            return comments;
        }
        public InspectionCommentModel AppendComment(InspectionCommentModel root, InspectionCommentModel insertion)
        {
            // I am gonna assume that the Parent is actually a child
            // for obvious reasons
            if (root.Parent != null)
            {
                return AppendComment(root.Parent, insertion);
            }
            root.Parent = insertion;
            root.ParentId = insertion.Id;
            return root;
        }
        public async Task<Guid> AddCommentToConsulation(Guid id, CommentCreateModel commentCreateModel)
        {
            InspectionConsultationModel consulation = await dbContext.Consultation
                .Include(c => c.RootComment)
                    .ThenInclude( rc => rc.Parent)
                .FirstOrDefaultAsync(c => c.Id == id);
            InspectionCommentModel insertion = mapper.Map<InspectionCommentModel>(commentCreateModel);
            InspectionCommentModel parent = AppendComment(consulation.RootComment, insertion);
            dbContext.InspectionComment.Update(parent);
            await dbContext.SaveChangesAsync();
            return insertion.Id??Guid.Empty;
        }
        public async Task EditComment(Guid id, InspectionCommentCreateModel commentCreateModel)
        {
            var commentModel = await dbContext.InspectionComment.FirstOrDefaultAsync(c=>c.Id == id);
            Guid userId = Guid.Parse(httpContext.HttpContext.User.FindFirst("UserId").Value);
            if(commentModel.AuthorId != userId)
            {
                throw new UnauthorizedAccessException();
            }

            if(id == null)
            {
                throw new DataException();
            }
            var comment = mapper.Map<InspectionCommentCreateModel, InspectionCommentModel>(commentCreateModel, commentModel);
            dbContext.Update(commentModel);
            await dbContext.SaveChangesAsync();
        }

    }
}
