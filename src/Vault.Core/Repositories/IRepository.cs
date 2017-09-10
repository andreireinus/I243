using System.Linq;
using System.Threading.Tasks;

namespace Vault.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);

        Task<OperationResult<T>> CreateAsync(T entity);
        Task<OperationResult<T>> UpdateAsync(T item);
    }
}
