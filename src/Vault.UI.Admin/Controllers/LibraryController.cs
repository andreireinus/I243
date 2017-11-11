using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vault.Core;
using Vault.Core.Repositories;
using Vault.UI.Admin.Infrastructure;
using Vault.UI.Admin.ModelMapping;
using Vault.UI.Admin.Models.Library;

namespace Vault.UI.Admin.Controllers
{
    public class LibraryController : Controller
    {
        private readonly LibraryAdministration _administration;
        private readonly ILocationRepository _locationRepository;

        public LibraryController(LibraryAdministration administration, ILocationRepository locationRepository)
        {
            _administration = administration ?? throw new ArgumentNullException(nameof(administration));
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        }

        public async Task<IActionResult> Index()
        {
            var items = (await _administration.AvailableItemsAsync()).ToViewModel();

            return View(items);
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
                var result = await _administration.AddAsync(model.ToLibaryItem());

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
            var item = await _administration.GetAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var model = item.ToEditViewModel();
            model.Locations = (await _locationRepository.GetAllAsync()).ToSelectListItem();
            return View(model);
        }

        public async Task<IActionResult> EditPost(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var item = await _administration.GetAsync(model.Id);
                if (item == null)
                {
                    return NotFound();
                }

                var result = await _administration.UpdateAsync(model.ToLibaryItem(item));

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