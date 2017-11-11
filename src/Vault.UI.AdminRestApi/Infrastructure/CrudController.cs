using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Vault.Core;

namespace Vault.UI.AdminRestApi.Infrastructure
{
    public abstract class CrudController<T> : Controller where T : class, IEntity
    {
        private readonly ICrudInteractor<T> _interactor;

        protected CrudController(ICrudInteractor<T> interactor)
        {
            _interactor = interactor ?? throw new ArgumentNullException(nameof(interactor));
        }


        [HttpGet]
        [Route("")]
        public virtual async Task<T[]> GetAll()
        {
            var items = await _interactor.GetAllAsync();

            return items.Entity;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<T> Get(int id)
        {
            var result = await _interactor.GetAsync(id);

            return result.Entity;
        }

        [HttpPost]
        [Route("")]
        public virtual async Task<T> Create([FromBody] T entity)
        {
            var result = await _interactor.CreateAsync(entity);

            return result.Entity;
        }

        [HttpPut]
        [Route("{id}")]
        public virtual async Task<T> Update(int id, [FromBody] T entity)
        {
            var result = await _interactor.UpdateAsync(entity);

            return result.Entity;
        }

    }
}
