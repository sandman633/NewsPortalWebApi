using System.ComponentModel.DataAnnotations;

namespace NewsPortal.DAL.Request.GroupPolicy
{
    /// <summary>
    /// Request new Group Policy model.
    /// </summary>
    public class NewGroupPolicyRequest
    {
        /// <summary>
        /// GroupId.
        /// </summary>
        [Required]
        public int GroupId { get; set; }
        /// <summary>
        /// Policy type.
        /// </summary>
        [Required]
        public string PolicyType { get; set; }
        /// <summary>
        /// Policy value.
        /// </summary>
        [Required]
        public short PolicyValue { get; set; }
    }
}
