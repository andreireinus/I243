using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class LibraryAdministration
    {
        private readonly ILibraryItemRepository _repository;

        public LibraryAdministration(ILibraryItemRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<LibraryItem>> AddAsync(LibraryItem libraryItem)
        {
            return _repository.CreateAsync(libraryItem);
        }
    }
}
