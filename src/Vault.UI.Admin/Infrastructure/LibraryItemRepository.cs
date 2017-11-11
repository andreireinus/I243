using System.Linq;
using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.UI.Admin.Infrastructure
{
    public class LibraryItemRepository : Repository<Book>, ILibraryItemRepository
    {
        public Task<Book[]> AvailableItemsAsync()
        {
            return Task.FromResult(Items.Where(a => a.IsAvailable).ToArray());
        }
    }
}
