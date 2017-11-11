using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vault.Core;
using Vault.Core.Repositories;

namespace Vault.UI.Admin.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected static readonly List<T> Items = new List<T>();

        public IQueryable<T> Query()
        {
            return Items.AsQueryable();
        }

        public Task<OperationResult<T>> GetAsync(int id)
        {
            return Task.FromResult(new OperationResult<T>(Items.Find(e => e.Id == id)));
        }

        public Task<OperationResult<T>> CreateAsync(T entity)
        {
            entity.Id = 1;
            if (Items.Any())
            {
                entity.Id = Items.Max(a => a.Id) + 1;
            }

            Items.Add(entity);

            return Task.FromResult(new OperationResult<T>(entity));
        }

        public Task<OperationResult<T>> UpdateAsync(T entity)
        {
            return Task.FromResult(new OperationResult<T>(entity));
        }
    }
}