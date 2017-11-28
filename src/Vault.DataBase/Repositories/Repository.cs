using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vault.Core;
using Vault.Core.Repositories;

namespace Vault.DataBase.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;

        protected Repository(DataContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> Query()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public async Task<OperationResult<T>> GetAsync(int id)
        {
            var result = await Query().FirstOrDefaultAsync(a => a.Id == id);

            if (result == default(T))
            {
                return new OperationResult<T>("Not found");
            }

            return new OperationResult<T>(result);
        }

        public async Task<OperationResult<T>> CreateAsync(T entity)
        {
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new OperationResult<T>(result.Entity);
        }

        public async Task<OperationResult<T>> UpdateAsync(T entity)
        {
            var result = _context.Attach(entity);
            result.State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return new OperationResult<T>(result.Entity);
        }
    }
}