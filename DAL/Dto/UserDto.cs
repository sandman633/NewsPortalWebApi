namespace DAL.Dto
{
    /// <summary>
    /// User.
    /// </summary>
    public class UserDto : BaseDto
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Surname.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Age.
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}