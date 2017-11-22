using System.Threading.Tasks;

namespace Vault.Core
{
    public interface ICrudInteractor<T> where T : class, IEntity
    {
        Task<OperationResult<T>> CreateAsync(T entity);
        Task<OperationResult<T>> UpdateAsync(T entity);
        Task<OperationResult<T>> GetAsync(int id);
        Task<OperationResult<T[]>> GetAllAsync();
    }
}
