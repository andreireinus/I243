using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vault.Core;
using Vault.Core.Entities;
using Vault.Core.Repositories;
using Vault.UI.Admin.Infrastructure;
using Vault.UI.Admin.ModelMapping;
using Vault.UI.Admin.Models.Library;

namespace Vault.UI.Admin.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ICrudInteractor<Book> _crudInteractor;
        private readonly ILocationRepository _locationRepository;

        public LibraryController(ILocationRepository locationRepository, ICrudInteractor<Book> crudInteractor)
        {
            _crudInteractor = crudInteractor ?? throw new ArgumentNullException(nameof(crudInteractor));
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        }

        public async Task<IActionResult> Index()
        {
            var result = await _crudInteractor.GetAllAsync();

            return View(result.Entity.ToViewModel());
        }

        public async Task<IActionResult> Create()
        {
            return View(new CreateViewModel
            {
                Locations = (await _locationRepository.GetAllAsync()).ToSelectListItem()
            });
        }

        public async Task<IActionResult> CreatePost(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _crudInteractor.CreateAsync(model.ToLibaryItem());

                if (result.Success)
                {
                    return RedirectToAction("Details", result.Entity.Id);
                }

                ModelState.AddOperationResultErrors(result.ErrorMessages);
            }

            model.Locations = (await _locationRepository.GetAllAsync()).ToSelectListItem();
            return View("Create", model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _crudInteractor.GetAsync(id);
            if (!result.Success)
            {
                return NotFound();
            }

            var model = result.Entity.ToEditViewModel();
            model.Locations = (await _locationRepository.GetAllAsync()).ToSelectListItem();
            return View(model);
        }

        public async Task<IActionResult> EditPost(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _crudInteractor.GetAsync(model.Id);
                if (!result.Success)
                {
                    return NotFound();
                }

                result = await _crudInteractor.UpdateAsync(model.ToLibaryItem(result.Entity));
                if (result.Success)
                {
                    return RedirectToAction("Details", result.Entity.Id);
                }

                ModelState.AddOperationResultErrors(result.ErrorMessages);
            }

            model.Locations = (await _locationRepository.GetAllAsync()).ToSelectListItem();
            return View("Edit", model);
        }

        public IActionResult Details(int id)
        {
            throw new NotImplementedException();
        }
    }
}