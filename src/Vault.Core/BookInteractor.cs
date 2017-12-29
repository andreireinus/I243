using System;
using System.Linq;
using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class BookInteractor : CrudInteractor<Book>, IBookInteractor
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly ILenderRepository _lenderRepository;
        private readonly ILendingRecordRepository _lendingRepository;

        public BookInteractor(IRepository<Book> bookRepository, ILenderRepository lenderRepository, ILendingRecordRepository lendingRepository) : base(bookRepository)
        {
            _bookRepository = bookRepository;
            _lenderRepository = lenderRepository;
            _lendingRepository = lendingRepository;
        }

        public async Task<OperationResult<LendingRecord>> Lend(int bookId, int lenderId, DateTime @from, DateTime to)
        {
            var bookResult = await _bookRepository.GetAsync(bookId);
            if (!bookResult.Success)
            {
                return new OperationResult<LendingRecord>("Book not found!", bookResult.ErrorMessages);
            }

            var lenderResult = await _lenderRepository.GetAsync(lenderId);
            if (!lenderResult.Success)
            {
                return new OperationResult<LendingRecord>("Lender not found!", lenderResult.ErrorMessages);
            }

            var book = bookResult.Entity;
            var record = new LendingRecord
            {
                From = @from,
                To = to,
                BookId = bookId,
                LenderId = lenderId
            };

            var createResult = await _lendingRepository.CreateAsync(record);
            if (!createResult.Success)
            {
                return new OperationResult<LendingRecord>("Creation of lending record failed!", createResult.ErrorMessages);
            }

            book.IsAvailable = false;
            var updateResult = await _bookRepository.UpdateAsync(book);
            if (!updateResult.Success)
            {
                return new OperationResult<LendingRecord>("Updating book availability failed!", updateResult.ErrorMessages);
            }

            return createResult;
        }

        public async Task<OperationResult<LendingRecord>> Return(int bookId)
        {
            var record = _lendingRepository.Query()
                .FirstOrDefault(a => a.Book.Id == bookId && !a.Returned.HasValue);

            if (record == default(LendingRecord))
            {
                return new OperationResult<LendingRecord>("Lending record not found, already returned?");
            }

            record.Returned = DateTime.Now;
            var updateResult = await _lendingRepository.UpdateAsync(record);
            if (!updateResult.Success)
            {
                return new OperationResult<LendingRecord>("Updating lending record has failed!", updateResult.ErrorMessages);
            }

            record.Book.IsAvailable = true;
            var bookResult = await _bookRepository.UpdateAsync(record.Book);
            if (!bookResult.Success)
            {
                return new OperationResult<LendingRecord>("Updating a book has failed!", bookResult.ErrorMessages);
            }

            return updateResult;
        }
    }
}
