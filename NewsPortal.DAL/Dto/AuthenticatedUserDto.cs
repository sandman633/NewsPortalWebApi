namespace NewsPortal.DAL.Dto
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
