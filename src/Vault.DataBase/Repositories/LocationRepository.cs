using Vault.Core.Entities;

namespace Vault.DataBase.Repositories
{
    public class LocationRepository : Repository<Location>
    {
        public LocationRepository(DataContext context) : base(context)
        {
        }
    }
}