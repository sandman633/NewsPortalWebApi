using System.Collections.Generic;

namespace NewsPortal.Model.Domain
{
    public class Group : BaseEntity
    {
        /// <summary>
        /// Group  name.
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        ///  Collection User Group.
        /// </summary>
        public ICollection<UserGroup> UserGroups { get; set; }
        /// <summary>
        ///  Collection Group policies.
        /// </summary>
        public ICollection<GroupPolicy> GroupPolicies { get; set; }
    }
}
