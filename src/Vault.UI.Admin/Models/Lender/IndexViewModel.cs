using System.ComponentModel.DataAnnotations;

namespace Vault.UI.Admin.Models.Lender
{
    public class IndexViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
