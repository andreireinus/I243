using System;
using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class Library
    {
        private readonly IBookRepository _repository;

        public Library(IBookRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<Book>> AddAsync(Book book)
        {
            return _repository.CreateAsync(book);
        }
    }
}
