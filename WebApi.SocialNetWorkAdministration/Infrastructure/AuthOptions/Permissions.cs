using System;

namespace WebApi.SocialNetWorkAdministration.Infrastructure.AuthOptions
{

    public class UserPermission
    {
        public string PermissionType { get;}
        public Permissions Permissions { get; }
    }

    

    [Flags]
    public enum Permissions : ushort
    {
        Read = 1,
        Create = 2,
        Update = 4,
        Delete = 8,
    }
}
