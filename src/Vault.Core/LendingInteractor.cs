using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class LendingInteractor : CrudInteractor<LendingRecord>, ILendingInteractor
    {
        public LendingInteractor(IRepository<LendingRecord> bookRepository) : base(bookRepository)
        {
        }

        public Task<OperationResult<LendingRecord>> Find(int bookId)
        {
            throw new System.NotImplementedException();
        }
    }
}