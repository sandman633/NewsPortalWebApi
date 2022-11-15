namespace NewsPortal.DAL.Response.GroupPolicy
{
    /// <summary>
    /// Group Policy response.
    /// </summary>
    public class GroupPolicyResponse
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Group Id.
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// Policy Type.
        /// </summary>
        public string PolicyType { get; set; }
        /// <summary>
        /// Policy Value.
        /// </summary>
        public string PolicyValue { get; set; }
    }
}
