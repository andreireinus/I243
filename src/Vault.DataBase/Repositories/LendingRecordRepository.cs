using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.DataBase.Repositories
{
    public class LendingRecordRepository : Repository<LendingRecord>, ILendingRecordRepository
    {
        public LendingRecordRepository(DataContext context) : base(context)
        {
        }

        public override IQueryable<LendingRecord> Query()
        {
            return base.Query()
                .Include(a=>a.Book)
                .Include(a=>a.Lender);
        }

        public Task<LendingRecord[]> GetAllLateAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}