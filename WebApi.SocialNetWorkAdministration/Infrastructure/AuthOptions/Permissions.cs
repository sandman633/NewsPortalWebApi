using System;

namespace WebApi.SocialNetWorkAdministration.Infrastructure.AuthOptions
{
    [Flags]
    public enum Permissions : ushort
    {
        Read = 1,
        Create = 2,
        Update = 4,
        Delete = 8,
    }
}
