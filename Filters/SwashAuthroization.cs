using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiProject.Filters;
public class AuthResponsesOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<AuthorizeAttribute>();

        if (authAttributes.Any())
        {
            OpenApiSecurityScheme scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" } };
            var securityRequirement = new OpenApiSecurityRequirement()
            {
                [scheme] = new List<string>()
            };
            operation.Security = new List<OpenApiSecurityRequirement> { securityRequirement };
            // Already added
            // operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
        }
    }
}