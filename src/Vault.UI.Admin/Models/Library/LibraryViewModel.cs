using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vault.UI.Admin.Models.Library
{
    public class CreateViewModel
    {
        public string Name { get; set; }
        public SelectListItem[] Locations { get; set; }
        public int LocationId { get; set; }
    }

    public class EditViewModel : CreateViewModel
    {
        public int Id { get; set; }
    }

    public class IndexViewModel
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
    }
}
