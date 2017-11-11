using System.Collections.Generic;

namespace Vault.Core.Entities
{
    public class LibraryItem : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public bool IsAvailable { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
