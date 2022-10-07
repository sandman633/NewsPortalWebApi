namespace DAL.Request.GroupPolicy
{
    /// <summary>
    /// Request update Group Policy model.
    /// </summary>
    public class UpdateGroupPolicyRequest : NewGroupPolicyRequest
    {
        public int Id { get; set; }
    }
}
