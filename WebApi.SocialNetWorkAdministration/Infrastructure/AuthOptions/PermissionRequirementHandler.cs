using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using WebApi.SocialNetWorkAdministration.Infrastructure.Exceptions;

namespace WebApi.SocialNetWorkAdministration.Infrastructure.AuthOptions
{
    public class PermissionRequirementHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            bool isHavePermission = false;
            var permissinClaims = context.User.Claims
                                .Where(x => x.Type == requirement.Permission);
            var isAuthenticated = context.User.Identities.FirstOrDefault().IsAuthenticated;
            if (!isAuthenticated)
            {
                throw new AuthentificationException(401, "The User is unauthorized!");
            }
            if (permissinClaims == null)
            {
                throw new AuthentificationException(403,"The User dont have any claims!");
            }

            foreach (var permissinClaim in permissinClaims)
            {
                var value = (Permissions)ushort.Parse(permissinClaim.Value);
                if (value.HasFlag(requirement.PermissionValue))
                    isHavePermission = true;
            }

            if (isHavePermission)
                context.Succeed(requirement);
            else
                throw new AuthentificationException(403, "The user does not have permission to access the requested resource",$"User dont have permission {requirement.Permission} with right {requirement.PermissionValue.ToString()}");

            return Task.CompletedTask;
        }
    }

}
