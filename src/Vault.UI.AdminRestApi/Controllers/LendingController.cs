using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Vault.Core;
using Vault.Core.Entities;
using Vault.UI.AdminRestApi.Infrastructure;

namespace Vault.UI.AdminRestApi.Controllers
{
    [Route("api/[controller]")]
    public class LendingController : CrudController<LendingRecord>
    {
        private readonly ILendingInteractor _interactor;

        public LendingController(ILendingInteractor interactor) : base(interactor)
        {
            _interactor = interactor;
        }

        [SwaggerOperation("LendingFind")]
        [HttpGet]
        [Route("find/{bookId}")]
        public async Task<LendingRecord> Find(int bookId)
        {
            var result = await _interactor.Find(bookId);

            return result.Entity;
        }

        [SwaggerOperation("LendingCreate")]
        public override Task<LendingRecord> Create(LendingRecord entity)
        {
            return base.Create(entity);
        }

        [SwaggerOperation("LendingUpdate")]
        public override Task<LendingRecord> Update(int id, LendingRecord entity)
        {
            return base.Update(id, entity);
        }

        [SwaggerOperation("LendingGetAll")]
        public override Task<LendingRecord[]> GetAll()
        {
            return base.GetAll();
        }

        [SwaggerOperation("LendingGet")]
        public override Task<LendingRecord> Get(int id)
        {
            return base.Get(id);
        }
    }
}