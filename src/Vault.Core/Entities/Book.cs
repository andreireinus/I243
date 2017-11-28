using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vault.Core.Entities
{
    public class Book : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        //public virtual ICollection<Picture> Pictures { get; set; }
    }
}
