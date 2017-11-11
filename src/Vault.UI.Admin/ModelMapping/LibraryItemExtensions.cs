using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.UI.Admin.Models;

namespace Vault.UI.Admin.ModelMapping
{
    public static class LibraryItemExtensions
    {
        public static LibraryViewModel.IndexViewModel[] ToViewModel(this LibraryItem[] items)
        {
            return items.Select(i => new LibraryViewModel.IndexViewModel()
            {
                Id = i.Id,
                Name = i.Name,
                IsAvailable = i.IsAvailable,
                Location = i.Location.Name,
                
                
            }).ToArray();
        }
    }
}
