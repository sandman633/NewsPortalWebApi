namespace NewsPortal.DAL.Dto
{
    /// <summary>
    /// Link relationship between <see cref="UserDto"/> and <see cref="RoleDto"/>.
    /// </summary>
    public class UserRoleDto : BaseDto
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
        /// Role id.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Role.
        /// </summary>
        public RoleDto Role { get; set; }
    }
}