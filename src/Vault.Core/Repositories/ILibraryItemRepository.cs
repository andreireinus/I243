using System.Threading.Tasks;
using Vault.Core.Entities;

namespace Vault.Core.Repositories
{
    public interface ILibraryItemRepository : IRepository<LibraryItem>
    {
        Task<LibraryItem[]> AvailableItemsAsync();
        
    }
}