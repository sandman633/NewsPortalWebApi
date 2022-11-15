using Microsoft.AspNetCore.Authorization;

namespace NewsPortal.WebApi.Infrastructure.AuthOptions
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get;  }
        public Permissions PermissionValue { get; }
        public PermissionRequirement(string permission, Permissions permissionValue)
        {
            Permission = permission;
            PermissionValue = permissionValue;
        }
    }

}
