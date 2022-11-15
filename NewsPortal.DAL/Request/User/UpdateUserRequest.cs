using System.ComponentModel.DataAnnotations;

namespace NewsPortal.DAL.Request.User
{
    /// <summary>
    /// Update request for user.
    /// </summary>
    public class UpdateUserRequest
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// LastName.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Age.
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
    }
}
