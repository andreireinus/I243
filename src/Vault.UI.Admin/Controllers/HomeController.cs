using Microsoft.AspNetCore.Mvc;
using Vault.Core;
using Vault.UI.Admin.ModelMapping;

namespace Vault.UI.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReportInteractor _interactor;

        public HomeController(ReportInteractor interactor)
        {
            _interactor = interactor;
        }

        public IActionResult Index()
        {
            return View(_interactor.Available().ToViewModel("Available books", 0));
        }

        public IActionResult LoanedOut()
        {
            return View("Index", _interactor.LoanedOut().ToViewModel("Loaded out books", 1));
        }

        public IActionResult Deadline()
        {
            return View("Index", _interactor.OverDeadline().ToViewModel("Over deadline", 2));

        }
    }
}
