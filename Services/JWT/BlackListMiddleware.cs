// Bad implementation
using Microsoft.IdentityModel.Tokens;

namespace ApiProject.Services.JWT
{
    public class BlacklistMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IBlackListService _blacklistService;

        public BlacklistMiddleware(RequestDelegate next, IBlackListService blacklistService)
        {
            _next = next;
            _blacklistService = blacklistService;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            string? tokenJti = context.User.FindFirst("jti")?.Value;
            // Warning:
            // TODO: Check auth attribute or make it extension
            // Assuming that authentcation middleware works
            if (tokenJti == null)
            {
                await _next(context);
                return;
            }
            if (_blacklistService.IsTokenBlacklisted(tokenJti))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Token is blacklisted");
                return;
            }

            await _next(context);
        }
    }
}