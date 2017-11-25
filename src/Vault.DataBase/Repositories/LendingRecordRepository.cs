using Vault.Core.Entities;

namespace Vault.DataBase.Repositories
{
    public class LendingRecordRepository : Repository<LendingRecord>
    {
        public LendingRecordRepository(DataContext context) : base(context)
        {
        }
    }
}