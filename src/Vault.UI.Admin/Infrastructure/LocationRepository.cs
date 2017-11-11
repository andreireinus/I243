using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.UI.Admin.Infrastructure
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        static LocationRepository()
        {
            Items.Add(new Location { Id = 1, Name = "Shelf A"});
            Items.Add(new Location { Id = 2, Name = "Shelf B"});
        }

        public Task<Location[]> GetAllAsync()
        {
            return Task.FromResult(Items.ToArray());
        }
    }
}