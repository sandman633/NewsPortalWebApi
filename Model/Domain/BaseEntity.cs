using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    /// <summary>
    /// BaseEntity.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
