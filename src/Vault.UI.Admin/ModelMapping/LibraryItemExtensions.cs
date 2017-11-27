using System.Linq;
using Vault.Core.Entities;
using Vault.UI.Admin.Models.Library;

namespace Vault.UI.Admin.ModelMapping
{
    public static class LibraryItemExtensions
    {
        public static EditViewModel ToEditViewModel(this Book item)
        {
            return new EditViewModel
            {
                Id = item.Id,
                Name = item.Name,
                LocationId = item.Location.Id
            };
        }

        public static IndexViewModel[] ToViewModel(this Book[] items)
        {
            return items.Select(i => new IndexViewModel
            {
                Id = i.Id,
                Name = i.Name,
                IsAvailable = i.IsAvailable,
                Location = i.Location.Name,
            }).ToArray();
        }

        public static Book ToLibaryItem(this CreateViewModel model)
        {
            return new Book
            {
                IsAvailable = true,
                Name = model.Name,
                Location = new Location
                {
                    Id = model.LocationId
                }
            };
        }

        public static Book ToLibaryItem(this EditViewModel source, Book destination)
        {
            destination.Name = source.Name;
            destination.Location.Id = source.LocationId;

            return destination;
        }
    }
}
