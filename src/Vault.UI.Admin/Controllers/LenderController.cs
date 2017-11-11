using System.Linq;
using System.Threading.Tasks;
using Vault.Core;
using Vault.Core.Entities;
using Vault.UI.Admin.Infrastructure;
using Vault.UI.Admin.Models.Lender;

namespace Vault.UI.Admin.Controllers
{
    
    public class LenderController : CrudController<Lender, IndexViewModel, CreateViewModel, EditViewModel>
    {
        public LenderController(ICrudInteractor<Lender> interactor) : base(interactor)
        {
        }

        public override IndexViewModel[] MapToIndexViewModel(Lender[] source)
        {
            return source.Select(l => new IndexViewModel
            {
                Id = l.Id,
                Name = l.Name,
                Email = l.Email
            }).ToArray();
        }

        public override Lender MapFromCreateViewModel(CreateViewModel source)
        {
            return new Lender
            {
                Email = source.Email,
                Name = source.Name
            };
        }

        public override Task<CreateViewModel> FillViewModel(CreateViewModel source)
        {
            return Task.FromResult(source);
        }

        protected override Task<EditViewModel> FillViewModel(EditViewModel source)
        {
            return Task.FromResult(source);
        }

        protected override EditViewModel MapToUpdateViewModel(Lender entity)
        {
            return new EditViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email
            };
        }

        protected override Lender MapFromUpdateViewModel(Lender souce, EditViewModel model)
        {
            souce.Name = model.Name;
            souce.Email = model.Email;

            return souce;
        }
    }
}