using System.Threading.Tasks;
using Vault.Core.Entities;

namespace Vault.Core.Repositories
{
    public interface ILendingRecordRepository : IRepository<LendingRecord>
    {
        Task<LendingRecord[]> GetAllLateAsync();
    }
}