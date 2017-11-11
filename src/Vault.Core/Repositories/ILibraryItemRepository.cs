using System.Threading.Tasks;
using Vault.Core.Entities;

namespace Vault.Core.Repositories
{
    public interface ILibraryItemRepository : IRepository<Book>
    {
        Task<Book[]> AvailableItemsAsync();
        
    }
}