namespace NewsPortal.DAL.Dto
{
    public class GroupPolicyDto : BaseDto
    {
        /// <summary>
        /// Group id.
        /// </summary>
        public int? GroupId { get; set; }
        /// <summary>
        /// Group.
        /// </summary>
        public GroupDto Group { get; set; }
        /// <summary>
        /// Policy Type.
        /// </summary>
        public string PolicyType { get; set; }
        /// <summary>
        /// Policy Value.
        /// </summary>
        public short? PolicyValue { get; set; }
    }
}
