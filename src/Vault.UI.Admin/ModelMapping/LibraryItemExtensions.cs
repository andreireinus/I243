using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.UI.Admin.Models;
using Vault.UI.Admin.Models.Library;

namespace Vault.UI.Admin.ModelMapping
{
    public static class LibraryItemExtensions
    {
        public static EditViewModel ToEditViewModel(this LibraryItem item)
        {
            return new EditViewModel
            {
                Id = item.Id,
                Name = item.Name,
                LocationId = item.Location.Id
            };
        }

        public static IndexViewModel[] ToViewModel(this LibraryItem[] items)
        {
            return items.Select(i => new IndexViewModel()
            {
                Id = i.Id,
                Name = i.Name,
                IsAvailable = i.IsAvailable,
                Location = i.Location.Name,


            }).ToArray();
        }

        public static LibraryItem ToLibaryItem(this CreateViewModel model)
        {
            return new LibraryItem
            {
                IsAvailable = true,
                Name = model.Name,
                Location = new Location
                {
                    Id = model.LocationId
                }
            };
        }

        public static LibraryItem ToLibaryItem(this EditViewModel source, LibraryItem destination)
        {
            destination.Name = source.Name;
            destination.Location.Id = source.LocationId;

            return destination;
        }
    }
}
