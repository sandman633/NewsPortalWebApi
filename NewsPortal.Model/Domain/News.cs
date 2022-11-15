using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsPortal.Model.Domain
{
    public class News : BaseEntity
    {
        /// <summary>
        /// Navigation property for user
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Author Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Header of news
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Text of news
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Date of news creation
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Date of news update
        /// </summary>
        public DateTime UpdatedTime { get; set; }
        /// <summary>
        /// Comments
        /// </summary>
        public ICollection<Comments> Сomments { get; set; }
    }
}
