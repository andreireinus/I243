using System.Linq;
using System.Threading.Tasks;
using Vault.Core;
using Vault.Core.Entities;
using Vault.UI.Admin.Infrastructure;
using Vault.UI.Admin.Models.Location;

namespace Vault.UI.Admin.Controllers
{
    public class LocationController : CrudController<Location, IndexViewModel, CreateViewModel, EditViewModel>
    {
        public LocationController(ICrudInteractor<Location> interactor) : base(interactor)
        {
        }

        public override IndexViewModel[] MapToIndexViewModel(Location[] source)
        {
            return source.Select(s => new IndexViewModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToArray();
        }

        public override Task<CreateViewModel> FillViewModel(CreateViewModel source)
        {
            return Task.FromResult(source);
        }

        protected override Task<EditViewModel> FillViewModel(EditViewModel source)
        {
            return Task.FromResult(source);
        }

        public override Location MapFromCreateViewModel(CreateViewModel source)
        {
            return new Location
            {
                Name = source.Name
            };
        }

        protected override Location MapFromUpdateViewModel(Location source, EditViewModel model)
        {
            source.Name = model.Name;

            return source;
        }

        protected override EditViewModel MapToUpdateViewModel(Location entity)
        {
            return new EditViewModel
            {
                Name = entity.Name,
                Id = entity.Id
            };
        }
    }
}