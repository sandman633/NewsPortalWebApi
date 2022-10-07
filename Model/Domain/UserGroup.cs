using System.Collections.Generic;

namespace Model.Domain
{
    public class UserGroup : BaseEntity
    {
        /// <summary>
        /// User id.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// User.
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Group Id.
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// User.
        /// </summary>
        public Group Group { get; set; }
        /// <summary>
        /// Group  policies.
        /// </summary>
        public ICollection<GroupPolicy> GroupPolicies { get; set; }
    }
}
