
using Demo.Models;
using Demo.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProiectDAW2.Helpers.Attributes
{
    public class AuthorizationAttribute: Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;

        public AuthorizationAttribute(params Role[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusObject = new JsonResult(new { Message = "Unauthorized" })
            { StatusCode = StatusCodes.Status401Unauthorized };


            if(_roles == null)
            {
                context.Result = unauthorizedStatusObject;  
            }

            Producator? producator = context.HttpContext.Items["Producator"] as Producator;
            if (producator == null || !_roles.Contains(producator.Role))
            {
                context.Result = unauthorizedStatusObject;
            }
        }
    }
}
