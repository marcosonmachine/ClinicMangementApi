
using System.ComponentModel.DataAnnotations;
using ApiProject.Data;

namespace ApiProject.Attributes
{
    public class ValidSpecialityAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var specialityId = (Guid)value;
                var dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

                // Check if referral ID exists in the database
                if (!dbContext.Speciality.Any(r => r.Id == specialityId))
                {
                    return new ValidationResult("Invalid Speciality ID.");
                }
            }

            return ValidationResult.Success;
        }
    }
}