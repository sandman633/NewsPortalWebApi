using System;
using System.Text;

namespace NewsPortal.Model.Domain
{
    public class GroupPolicy : BaseEntity
    {
        /// <summary>
        /// Group id.
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Group.
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Policy Type.
        /// </summary>
        public string PolicyType { get; set; }

        /// <summary>
        /// Policy Value.
        /// </summary>
        public short PolicyValue { get; set; }
    }
}
