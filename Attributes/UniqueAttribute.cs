using System.ComponentModel.DataAnnotations;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// Ultra legendary bullshittery
public class UniqueReflectiveAttribute<TDbContext, TReflected, TProperty> : ValidationAttribute 
    where TDbContext : DbContext 
    where TReflected : class
{
    private string _targetPropertyName = null;
    public UniqueReflectiveAttribute(){}
    public UniqueReflectiveAttribute(string? targetPropertyName)
    {
        _targetPropertyName = targetPropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Weird ass shit
        var db = validationContext.GetService<TDbContext>();

        var propertyName = validationContext.MemberName;
        
        var existingEntity = db.Set<TReflected>()
            .FirstOrDefault
            (
                e => EF.Property<TProperty>(e, _targetPropertyName ?? propertyName)
                    .Equals(value)
            );

        if (existingEntity != null)
        {
            return new ValidationResult($"The value '{value}' for {propertyName} is already in use.");
        }

        return ValidationResult.Success;
    }
}