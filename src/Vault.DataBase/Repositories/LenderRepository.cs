using Vault.Core.Entities;

namespace Vault.DataBase.Repositories
{
    public class LenderRepository : Repository<Lender>
    {
        public LenderRepository(DataContext context) : base(context)
        {
        }
    }
}