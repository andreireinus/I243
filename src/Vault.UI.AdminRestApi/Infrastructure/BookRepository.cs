using System.Linq;
using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;
using Vault.UI.Admin.Infrastructure;

namespace Vault.UI.AdminRestApi.Infrastructure
{
    public class BookRepository : Repository<Book>, ILibraryItemRepository
    {
        public Task<Book[]> AvailableItemsAsync()
        {
            return Task.FromResult(Items.Where(a => a.IsAvailable).ToArray());
        }
    }
}
