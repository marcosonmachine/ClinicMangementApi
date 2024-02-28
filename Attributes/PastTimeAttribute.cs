using System;
using System.ComponentModel.DataAnnotations;

namespace ApiProject.Attributes
{

    public class PastDateTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime > DateTime.Now)
                {
                    return new ValidationResult("Input DateTime is in the future.");
                }
            }

            if (value is DateOnly dateOnly)
            {
                if (dateOnly > DateOnly.FromDateTime(DateTime.Now))
                {
                    return new ValidationResult("Input DateOnly is in the future.");
                }
            }

            if (value is DateTimeOffset dateTimeOffset)
            {
                if (dateTimeOffset > DateTimeOffset.Now)
                {
                    return new ValidationResult("Input DateTimeOffset is in the future.");
                }
            }

            return ValidationResult.Success;
        }
    }
}