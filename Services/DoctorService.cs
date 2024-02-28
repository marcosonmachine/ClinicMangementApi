using System.Runtime.InteropServices;
using ApiProject.Data;
using ApiProject.Managers;
using ApiProject.Models;
using ApiProject.Models.Base;
using ApiProject.Services.JWT;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public interface IDoctorService
    {
        public Task<TokenResponseModel> Register(DoctorRegisterModel doctor);
        public Task Edit(Guid docId, DoctorEditModel doctorEditModel);
        public DoctorModel FindByIdNoTracking(Guid docId);
        public Task<string> LoginAuthenticateUser(LoginCredentialsModel login);
        // public DoctorModel GetDoctor();
        // public TokenResponseModel Login();
    }

    public class DoctorService
    (
        ITokenService tokenService,
        IMapper mapper,
        ApplicationDbContext dbContext
    ) : IDoctorService
    {
        public async Task<TokenResponseModel> Register(DoctorRegisterModel doctor)
        {
            DoctorModel doc = mapper.Map<DoctorModel>(doctor);
            await dbContext.Doctor.AddAsync(doc);
            await dbContext.SaveChangesAsync();
            string Token = tokenService.CreateToken(doc);
            return new TokenResponseModel() { Token = Token };
        }

        public DoctorModel FindByIdNoTracking(Guid docId)
        {
            var doc = dbContext.Doctor.AsNoTracking().Include(o => o.Speciality)
            .FirstOrDefault(d => d.Id == docId);
            return doc;
        }
        public async Task Edit(Guid docId, DoctorEditModel doctorEditModel)
        {
            DoctorModel doc = mapper
                .Map<DoctorEditModel, DoctorModel>(
                    doctorEditModel,
                    FindByIdNoTracking(docId)
                );
            dbContext.Doctor.Update(doc);
            await dbContext.SaveChangesAsync();
        }
        public async Task<string> LoginAuthenticateUser(LoginCredentialsModel login)
        {
            DoctorModel doc = await dbContext.Doctor.AsNoTracking().FirstOrDefaultAsync(e => e.Email == login.Email);
            if (doc != null)
            {
                if (PasswordHasher.VerifyPassword(login.Password, doc.Password))
                {
                    return tokenService.CreateToken(doc);
                }
            }
            return "";
        }
    }
}