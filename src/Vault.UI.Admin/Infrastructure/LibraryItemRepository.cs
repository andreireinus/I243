using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vault.Core;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.UI.Admin.Infrastructure
{
    public class LibraryItemRepository : Repository<LibraryItem>, ILibraryItemRepository
    {
        public Task<LibraryItem[]> AvailableItemsAsync()
        {
            return Task.FromResult(Items.Where(a => a.IsAvailable).ToArray());
        }
    }
}
