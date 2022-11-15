using System.ComponentModel.DataAnnotations;

namespace NewsPortal.DAL.Request.User
{
    /// <summary>
    /// Request new user model.
    /// </summary>
    public class NewUserRequest
    {
        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// LastName.
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Age.
        /// </summary>
        [Required]
        public int Age { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
