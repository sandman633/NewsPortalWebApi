using NewsPortal.Model.Domain;
using System;

namespace NewsPortal.DAL.Dto
{
    public class UserTokenDto : BaseDto
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public string RefreshToken { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}