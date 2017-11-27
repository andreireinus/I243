using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vault.Core.Entities
{
    public class Lender : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public virtual ICollection<LendingRecord> LendingHistory { get; set; }
    }
}
