using System;

namespace Model.Domain
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
