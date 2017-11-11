using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vault.UI.Admin.Models
{
    public static class LibraryViewModel
    {
        public class AddViewModel
        {
            
        }

        public class IndexViewModel
        {
            public int Id { get; set; }
            public bool IsAvailable { get; set; }
            public string Location { get; set; }
            public string Name { get; set; }
        }
    }
}
