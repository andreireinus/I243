using System;
using System.Linq;
using System.Threading.Tasks;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public interface ICrudInteractor<T> where T : class, IEntity
    {
        Task<OperationResult<T>> CreateAsync(T entity);
        Task<OperationResult<T>> UpdateAsync(T entity);
        Task<OperationResult<T>> GetAsync(int id);
        Task<OperationResult<T[]>> GetAllAsync();
    }

    public class CrudInteractor<T> : ICrudInteractor<T> where T : class, IEntity
    {
        private readonly IRepository<T> _repository;

        public CrudInteractor(IRepository<T> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<OperationResult<T>> CreateAsync(T entity)
        {
            return _repository.CreateAsync(entity);
        }

        public Task<OperationResult<T>> UpdateAsync(T entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public Task<OperationResult<T>> GetAsync(int id)
        {
            return _repository.GetAsync(id);
        }

        public Task<OperationResult<T[]>> GetAllAsync()
        {
            var entities = _repository.Query().ToArray();

            return Task.FromResult(new OperationResult<T[]>(entities));
        }
    }
}
