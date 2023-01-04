using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Model.Domain
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Surname.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Age.
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User Phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// User roles.
        /// </summary>
        public ICollection<UserGroup> UserGroups { get; set; }
        /// <summary>
        /// User comments.
        /// </summary>
        public ICollection<Comments> Comments { get; set; }
        /// <summary>
        /// User news.
        /// </summary>
        public ICollection<News> News { get; set; }
        /// <summary>
        /// User refresh tokens.
        /// </summary>
        public ICollection<UserToken> UserTokens { get; set; }
    }
}
