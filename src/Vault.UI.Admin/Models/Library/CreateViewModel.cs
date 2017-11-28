using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vault.UI.Admin.Models.Library
{
    public class CreateViewModel
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public SelectListItem[] Locations { get; set; }

        [DisplayName("Location")]
        public int LocationId { get; set; }
    }
}