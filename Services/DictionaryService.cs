using System.ComponentModel.DataAnnotations;
using ApiProject.Data;
using ApiProject.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ApiProject.Services
{
    public interface IDictionaryApiService
    {
        public Task<Guid?> CreateSpeciality(SpecialityAddModel specialityAddModel);
        public Task<SpecialtiesPagedListModel> GetSpeciality(string name, [Range(1, 2147483647)] int? page, [Range(1, 2147483647)] int? size);
    }
    public class DictionaryApiService
    (
        ApplicationDbContext dbContext,
        IMapper mapper
    ) : IDictionaryApiService
    {
        public async Task<Guid?> CreateSpeciality(SpecialityAddModel specialityAddModel)
        {
            SpecialityModel specialityModel = mapper.Map<SpecialityModel>(specialityAddModel);
            try
            {
                await dbContext.Speciality.AddAsync(specialityModel);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // TODO: fix this
                return null;
            }
            return specialityModel.Id;
        }
        public async Task<SpecialtiesPagedListModel> GetSpeciality(string name, [Range(1, 2147483647)] int? page, [Range(1, 2147483647)] int? size)

        {
            IQueryable<SpecialityModel> query;
            if (name.IsNullOrEmpty())
            {
                query = dbContext.Speciality
                    .AsNoTracking();
            }
            else
            {
                query = dbContext.Speciality
                    .AsNoTracking()
                    .Where(e =>
                        e.Name.ToLower().Contains(name.ToLower()) == true);
            }
            PaginatedModel<SpecialityModel> pageList = await ApplicationDbContext.GetPageList<SpecialityModel>(
                   query, page ?? 1, size ?? 5
                );
            return mapper.Map<SpecialtiesPagedListModel>(pageList);
        }

    }
}