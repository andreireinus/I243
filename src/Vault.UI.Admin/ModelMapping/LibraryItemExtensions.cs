using System.Collections.Generic;
using System.Linq;
using Vault.Core.Entities;
using Vault.UI.Admin.Models.Library;

namespace Vault.UI.Admin.ModelMapping
{
    public static class LibraryItemExtensions
    {
        public static IndexViewModel[] ToViewModel(this IEnumerable<Book> items)
        {
            return items.Select(i => new IndexViewModel
            {
                Id = i.Id,
                Author = i.Author,
                Name = i.Name,
                IsAvailable = i.IsAvailable,
                Location = i.Location.Name,
            }).ToArray();
        }

        public static Book ToBook(this CreateViewModel model)
        {
            return new Book
            {
                IsAvailable = true,
                Author = model.Author,
                Name = model.Name,
                Location = new Location
                {
                    Id = model.LocationId
                }
            };
        }

        public static Book ToBook(this EditViewModel source, Book destination)
        {
            destination.Author = source.Author;
            destination.Name = source.Name;
            if (destination.Location == null)
            {
                destination.Location = new Location();
            }

            destination.Location.Id = source.LocationId;

            return destination;
        }
    }
}
