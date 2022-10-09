using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.SocialNetWorkAdministration.Infrastructure.AuthOptions
{
    public class PermissionRequirementHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            bool isHavePermission = false;
            var permissinClaims = context.User.Claims
                                .Where(x => x.Type == requirement.Permission); 
            if (permissinClaims == null)
            {
                context.Fail();
                
                return Task.CompletedTask;
            }

            foreach(var permissinClaim in permissinClaims)
            {
                var value = (Permissions)ushort.Parse(permissinClaim.Value);
                if (value.HasFlag(requirement.PermissionValue))
                    isHavePermission = true;
                    
            }

            if (isHavePermission)
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.CompletedTask;
        }
    }

}
