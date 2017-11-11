using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vault.Core;
using Vault.UI.Admin.ModelMapping;

namespace Vault.UI.Admin.Controllers
{
    public class LibraryController : Controller
    {
        private readonly LibraryAdministration _administration;

        public LibraryController(LibraryAdministration administration)
        {
            _administration = administration ?? throw new ArgumentNullException(nameof(administration));
        }

        public async Task<IActionResult> Index()
        {
            var items = (await _administration.AvailableItemsAsync()).ToViewModel();


            return View(items);
        }

        public IActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}