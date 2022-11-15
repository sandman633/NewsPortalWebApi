using NewsPortal.DAL.Dto;

namespace NewsPortal.NewsPortal.DAL.Dto
{
    /// <summary>
    /// DTO for authenticated User.
    /// </summary>
    public class AuthenticatedUserDto : BaseDto
    {
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
    }
}
