using System;
using System.Threading.Tasks;
using Vault.Core.Entities;

namespace Vault.Core
{
    public interface ILendingInteractor : ICrudInteractor<LendingRecord>
    {
        Task<OperationResult<LendingRecord>> Find(int bookId);
    }

    public interface IBookInteractor : ICrudInteractor<Book>
    {
        Task<OperationResult<LendingRecord>> Lend(int bookId, int lenderId, DateTime from, DateTime to);
        Task<OperationResult<LendingRecord>> Return(int bookId);
    }
}