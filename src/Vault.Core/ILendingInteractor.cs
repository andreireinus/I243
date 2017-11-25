using System.Threading.Tasks;
using Vault.Core.Entities;

namespace Vault.Core
{
    public interface ILendingInteractor : ICrudInteractor<LendingRecord>
    {
        Task<OperationResult<LendingRecord>> Find(int bookId);
    }
}