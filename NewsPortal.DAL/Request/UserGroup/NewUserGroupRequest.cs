using System.ComponentModel.DataAnnotations;

namespace NewsPortal.DAL.Request.UserGroup
{
    /// <summary>
    /// Request new user group model.
    /// </summary>
    public class NewUserGroupRequest
    {
        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        public int GroupId { get; set; }
        /// <summary>
        /// UserId.
        /// </summary>
        [Required]
        public int UserId { get; set; }
    }
}
