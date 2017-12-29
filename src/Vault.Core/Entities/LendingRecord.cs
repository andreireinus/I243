using System;
using System.ComponentModel.DataAnnotations;

namespace Vault.Core.Entities
{
    public class LendingRecord : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Lender Lender { get; set; }
        [Required]
        public Book Book { get; set; }
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        public DateTime? Returned { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int LenderId { get; set; }
    }
}