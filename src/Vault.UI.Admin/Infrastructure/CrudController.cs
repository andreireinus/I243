﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vault.Core;

namespace Vault.UI.Admin.Infrastructure
{
    public abstract class CrudController<T, TIndexVm, TCreateVm, TUpdateVm> : Controller
        where T : class, IEntity
        where TCreateVm : class, new()
        where TUpdateVm : class, IEntity
    {
        private readonly ICrudInteractor<T> _interactor;

        protected CrudController(ICrudInteractor<T> interactor)
        {
            _interactor = interactor;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _interactor.GetAllAsync();

            return View("Index", MapToIndexViewModel(result.Entity));
        }

        public async Task<IActionResult> Create()
        {
            var model = await FillViewModel(new TCreateVm());

            return View(model);
        }

        public async Task<IActionResult> CreatePost(TCreateVm model)
        {
            if (ModelState.IsValid)
            {
                var result = await _interactor.CreateAsync(MapFromCreateViewModel(model));

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddOperationResultErrors(result.ErrorMessages);
            }

            model = await FillViewModel(model);

            return View("Create", model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _interactor.GetAsync(id);
            if (!result.Success)
            {
                return NotFound();
            }

            var model = MapToUpdateViewModel(result.Entity);
            model = await FillViewModel(model);
            return View(model);
        }

        public async Task<IActionResult> EditPost(TUpdateVm model)
        {
            if (ModelState.IsValid)
            {
                var result = await _interactor.GetAsync(model.Id);
                if (!result.Success)
                {
                    return NotFound();
                }

                result = await _interactor.UpdateAsync(MapFromUpdateViewModel(result.Entity, model));
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddOperationResultErrors(result.ErrorMessages);
            }

            model = await FillViewModel(model);
            return View("Edit", model);
        }

        public abstract TIndexVm[] MapToIndexViewModel(T[] source);
        public abstract T MapFromCreateViewModel(TCreateVm source);
        public abstract Task<TCreateVm> FillViewModel(TCreateVm source);
        protected abstract Task<TUpdateVm> FillViewModel(TUpdateVm source);
        protected abstract TUpdateVm MapToUpdateViewModel(T entity);
        protected abstract T MapFromUpdateViewModel(T source, TUpdateVm model);
    }
}
