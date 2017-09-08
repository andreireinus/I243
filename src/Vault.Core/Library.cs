using System;
using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class Library
    {
        private readonly ILibraryItemRepository _repository;

        public Library(ILibraryItemRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<LibraryItem>> AddAsync(LibraryItem libraryItem)
        {
            return _repository.CreateAsync(libraryItem);
        }
    }
}
