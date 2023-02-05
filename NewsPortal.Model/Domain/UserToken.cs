using System;

namespace NewsPortal.Model.Domain
{
    public class UserToken : BaseEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }
        
        public string RefreshToken { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
