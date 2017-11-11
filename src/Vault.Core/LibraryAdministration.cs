using System;
using System.Linq;
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

        public Task<OperationResult<LibraryItem>> AddAsync(LibraryItem libraryItem)
        {
            return _libraryItemRepository.CreateAsync(libraryItem);
        }

        public Task<OperationResult<LibraryItem>> UpdateAsync(LibraryItem item)
        {
            return _libraryItemRepository.UpdateAsync(item);
        }

        public Task<LibraryItem[]> AvailableItemsAsync()
        {
            return _libraryItemRepository.AvailableItemsAsync();
        }

        public Task<OperationResult<LendingRecord>> CheckoutAsync(Lender lender, LibraryItem item, DateTime to)
        {
            var record = new LendingRecord
            {
                From = DateTime.Now,
                To = DateTime.Now.AddDays(14),
                Lender = lender,
                LibraryItem = item,
                Returned = null
            };

            return _lendingRepository.CreateAsync(record);
        }

        public Task<LibraryItem> GetAsync(int id)
        {
            return _libraryItemRepository.GetAsync(id);
        }
    }
}
