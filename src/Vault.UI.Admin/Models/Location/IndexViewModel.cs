using System.ComponentModel.DataAnnotations;
using Vault.Core;

namespace Vault.UI.Admin.Models.Location
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CreateViewModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }

    public class EditViewModel : CreateViewModel, IEntity
    {
        [Required]
        public int Id { get; set; }
    }
}
