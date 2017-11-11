using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Vault.Core;
using Vault.Core.Entities;
using Vault.UI.AdminRestApi.Infrastructure;

namespace Vault.UI.AdminRestApi.Controllers
{
    [Route("api/[controller]")]
    public class LenderController : CrudController<Lender>
    {
        public LenderController(ICrudInteractor<Lender> interactor) : base(interactor)
        {
        }

        [SwaggerOperation("LenderCreate")]
        public override Task<Lender> Create(Lender entity)
        {
            return base.Create(entity);
        }

        [SwaggerOperation("LenderUpdate")]
        public override Task<Lender> Update(int id, Lender entity)
        {
            return base.Update(id, entity);
        }

        [SwaggerOperation("LenderGetAll")]
        public override Task<Lender[]> GetAll()
        {
            return base.GetAll();
        }

        [SwaggerOperation("LenderGet")]
        public override Task<Lender> Get(int id)
        {
            return base.Get(id);
        }
    }
}