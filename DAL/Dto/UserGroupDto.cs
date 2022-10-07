using System.Collections.Generic;

namespace DAL.Dto
{
    public class UserGroupDto : BaseDto
    {
        /// <summary>
        /// User id.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// User.
        /// </summary>
        public UserDto User { get; set; }
        /// <summary>
        /// Group Id.
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// Group.
        /// </summary>
        public GroupDto Group { get; set; }
        /// <summary>
        /// Group  policies.
        /// </summary>
        public ICollection<GroupPolicyDto> GroupPolicies { get; set; }
    }
}
