using System.ComponentModel.DataAnnotations;

namespace Vault.UI.Admin.Models.Lender
{
    public class CreateViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}