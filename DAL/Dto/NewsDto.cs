using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Dto
{
    /// <summary>
    /// News Dto.
    /// </summary>
    public class NewsDto : BaseDto
    {
        /// <summary>
        /// User.
        /// </summary>
        public UserDto  User { get; set; }
        /// <summary>
        /// UserId.
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// News header. 
        /// </summary>
        public string Header { get; set; }
        /// <summary>
        /// News body.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Date of news update
        /// </summary>
        public DateTime UpdatedTime { get; set; }
        /// <summary>
        /// News comments.
        /// </summary>
        public ICollection<CommentsDto> Сomments { get; set; }
    }
}
