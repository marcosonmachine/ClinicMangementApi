// Middleware class doesn't work only on server operation

// using ApiProject.Services.JWT;
// using Microsoft.IdentityModel.Tokens;

// namespace ApiProject.Middlewares
// {
//     public class RevokeBlacklistToken
//     {
//         private readonly RequestDelegate _next;
//         private readonly IBlackListService _blackListService;

//         public RevokeBlacklistToken(RequestDelegate next, InMemoryBlacklistService blackListService)
//         {
//             _next = next;
//             _blackListService = blackListService;
//         }

//         public async Task InvokeAsync(HttpContext context)
//         {
//             string authorizationHeader = context.Request.Headers["Authorization"];


//             if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
//             {
//                 string token = authorizationHeader.Substring("Bearer ".Length).Trim();

//                 if (_blackListService.IsTokenBlacklisted(token))
//                 {
//                     throw new SecurityTokenExpiredException("Invalid token specified.");
//                 }
//             }

//             await _next(context);
//         }
//     }
// }
