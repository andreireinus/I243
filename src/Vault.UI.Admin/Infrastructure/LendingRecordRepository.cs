using System;
using System.Linq;
using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.UI.Admin.Infrastructure
{
    public class LendingRecordRepository : Repository<LendingRecord>, ILendingRecordRepository
    {
        public Task<LendingRecord[]> GetAllLateAsync()
        {
            return Task.FromResult(Items.Where(a => a.Returned == null && a.To > DateTime.Now).ToArray());
        }
    }
}