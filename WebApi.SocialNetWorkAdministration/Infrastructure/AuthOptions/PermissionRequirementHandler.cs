using Microsoft.AspNetCore.Authorization;
using Model.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.SocialNetWorkAdministration.Infrastructure.AuthOptions
{
    public class PermissionRequirementHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {

            var permissinClaim = context.User.Claims
                                .ToList()
                                .Find(x => x.Type == requirement.Permission); 
            if (permissinClaim == null)
            {
                
                context.Fail();
                
                return Task.CompletedTask;
            }
            var value = (Permissions) ushort.Parse(permissinClaim.Value);

            if (value.HasFlag(requirement.PermissionValue))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }

}
