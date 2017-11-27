using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.DataBase.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(DataContext context) : base(context)
        {
        }

        public Task<Location[]> GetAllAsync()
        {
            return Query().OrderBy(a => a.Name).ToArrayAsync();
        }
    }
}