using ApiProject.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DoctorModel> Doctor { get; set; }
        public DbSet<InspectionConsultationModel> Consultation { get; set; }
        public DbSet<DiagnosisModel> Diagnosis { get; set; }
        public DbSet<InspectionCommentModel> InspectionComment { get; set; }
        public DbSet<InspectionModel> Inspection { get; set; }
        public DbSet<PatientModel> Patient { get; set; }
        public DbSet<SpecialityModel> Speciality { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // public PaginatedModel<TEntity> PaginationSearch<TEntity>(string propertyName, string matchName = "", int page = 1, int pageSize = 5)
        //     where TEntity : class
        // {
        //     // Using linq for this is horrible overall but anyways
        //     var query = this.Set<TEntity>()
        //           .AsNoTracking()
        //           .Where(e => propertyName != null &&
        //                       EF.Property<string>(e, propertyName).ToLower().Contains(matchName.ToLower()) == true);

        //     int totalMatchCount = query.Count();

        //     PaginatedModel<TEntity> searchResult = new PaginatedModel<TEntity>
        //     {
        //         Entities = query.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
        //         Pagination = new PageInfoModel
        //         {
        //             Size = pageSize,
        //             Count = (int)Math.Ceiling((decimal)(query.Count() / pageSize)),
        //             Current = page
        //         }
        //     };
        //     return searchResult;
        // }
        public static async Task<PaginatedModel<T>> GetPageList<T>(IQueryable<T> source, int pageIndex, int pageSize)
            where T : class
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedModel<T>
            {
                Entities = items,
                Pagination = new PageInfoModel
                {
                    Size = pageSize,
                    Count = count / pageSize + 1,
                    Current = pageIndex
                }
            };
        }
    }
}
