using System.Threading.Tasks;
using Vault.Core.Entities;

namespace Vault.Core.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<Location[]> GetAllAsync();
    }
}
