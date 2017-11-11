using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vault.UI.Admin.Models.Library
{
    public class CreateViewModel
    {
        public string Name { get; set; }
        public SelectListItem[] Locations { get; set; }
        public int LocationId { get; set; }
    }
}