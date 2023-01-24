using ProiectDAW2.Helpers.Jwt;
using ProiectDAW2.Servicies;

namespace ProiectDAW2.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IProducatorService producatorService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();

            var userId = jwtUtils.ValidateJwtToken(token);

            if(userId != Guid.Empty)
            {
                httpContext.Items["Producator"] = producatorService.GetById(userId);
            }

            await _next(httpContext);
        }

    }
}
