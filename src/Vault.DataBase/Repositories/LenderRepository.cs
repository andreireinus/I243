using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.DataBase.Repositories
{
    public class LenderRepository : Repository<Lender>, ILenderRepository
    {
        public LenderRepository(DataContext context) : base(context)
        {
        }
    }
}