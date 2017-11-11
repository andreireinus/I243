using System;
using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class LibraryAdministration
    {
        private readonly ILibraryItemRepository _libraryItemRepository;
        private readonly ILendingRecordRepository _lendingRepository;

        public LibraryAdministration(ILibraryItemRepository libraryItemRepository, ILendingRecordRepository lendingRepository)
        {
            _libraryItemRepository = libraryItemRepository ?? throw new ArgumentNullException(nameof(libraryItemRepository));
            _lendingRepository = lendingRepository ?? throw new ArgumentNullException(nameof(lendingRepository));
        }

        public Task<OperationResult<Book>> AddAsync(Book book)
        {
            return _libraryItemRepository.CreateAsync(book);
        }

        public Task<OperationResult<Book>> UpdateAsync(Book item)
        {
            return _libraryItemRepository.UpdateAsync(item);
        }

        public Task<Book[]> AvailableItemsAsync()
        {
            return _libraryItemRepository.AvailableItemsAsync();
        }

        public Task<OperationResult<LendingRecord>> CheckoutAsync(Lender lender, Book item, DateTime to)
        {
            var record = new LendingRecord
            {
                From = DateTime.Now,
                To = DateTime.Now.AddDays(14),
                Lender = lender,
                Book = item,
                Returned = null
            };

            return _lendingRepository.CreateAsync(record);
        }
    }
}
