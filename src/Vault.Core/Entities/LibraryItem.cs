using System.Security.Principal;

namespace Vault.Core.Entities
{
    public class LibraryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public bool IsAvailable { get; set; }
    }
}
