using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vault.Core;
using Vault.Core.Entities;
using Vault.Core.Repositories;
using Vault.UI.Admin.Infrastructure;
using Vault.UI.Admin.ModelMapping;
using Vault.UI.Admin.Models.Library;

namespace Vault.UI.Admin.Controllers
{
    public class LibraryController : CrudController<Book, IndexViewModel, CreateViewModel, EditViewModel>
    {
        private readonly IBookInteractor _interactor;
        private readonly ILocationRepository _locationRepository;
        private readonly ILenderRepository _lenderRepository;

        public LibraryController(IBookInteractor interactor, ILocationRepository locationRepository, ILenderRepository lenderRepository) : base(interactor)
        {
            _interactor = interactor;
            _locationRepository = locationRepository;
            _lenderRepository = lenderRepository;
        }

        public async Task<IActionResult> Lend(int bookId)
        {
            var result = await _interactor.GetAsync(bookId);
            if (!result.Success)
            {
                return NotFound();
            }

            var model = new LendingViewModel
            {
                BookId = bookId,
                BookName = result.Entity.Author + ", " + result.Entity.Name,
                Lenders = await GetLendersDropdown(),
                From = DateTime.Now,
                To = DateTime.Now.AddDays(14)
            };

            return View("Lend", model);

        }

        public async Task<IActionResult> LendPost(LendingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _interactor.Lend(model.BookId, model.LenderId, model.From, model.To);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddOperationResultErrors(result.ErrorMessages);
            }

            model.Lenders = await GetLendersDropdown();
            return View("Lend", model);
        }

        public async Task<IActionResult> Return(int bookId)
        {
            var result = await _interactor.Return(bookId);

            return RedirectToAction("Index");
        }

        public override IndexViewModel[] MapToIndexViewModel(Book[] source)
        {
            return source.ToViewModel();
        }

        public override async Task<CreateViewModel> FillViewModel(CreateViewModel source)
        {
            source.Locations = (await _locationRepository.GetAllAsync()).ToSelectListItem();

            return source;
        }

        protected override async Task<EditViewModel> FillViewModel(EditViewModel source)
        {
            source.Locations = (await _locationRepository.GetAllAsync()).ToSelectListItem();

            return source;
        }

        public override Book MapFromCreateViewModel(CreateViewModel source)
        {
            return source.ToBook();
        }

        protected override EditViewModel MapToUpdateViewModel(Book entity)
        {
            return new EditViewModel
            {
                Id = entity.Id,
                Author = entity.Author,
                Name = entity.Name,
                LocationId = entity.Location.Id
            };
        }

        protected override Book MapFromUpdateViewModel(Book source, EditViewModel model)
        {
            return model.ToBook(source);
        }

        private Task<SelectListItem[]> GetLendersDropdown()
        {
            return _lenderRepository.Query().OrderBy(a => a.Name).Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToArrayAsync();
        }
    }
}