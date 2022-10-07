using System.ComponentModel.DataAnnotations;

namespace DAL.Request.Group
{
    /// <summary>
    /// Request new Group model.
    /// </summary>
    public class NewGroupRequest
    {
        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        public string GroupName { get; set; }
    }
}
