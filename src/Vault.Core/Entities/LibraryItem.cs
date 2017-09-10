using System.Collections.Generic;
using System.Security.Principal;

namespace Vault.Core.Entities
{
    public class LibraryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public bool IsAvailable { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }

    }


    public class Picture
    {
        public int Id { get; set; }
        public LibraryItem LibraryItem { get; set; }
        public byte[] Bytes { get; set; }
    }
}
