using System.Threading.Tasks;

namespace Vault.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<OperationResult<T>> CreateAsync(T entity);
    }
}
