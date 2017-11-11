using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vault.Core;
using Vault.Core.Entities;

namespace Vault.UI.AdminRestApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly ICrudInteractor<Book> _interactor;

        public BookController(ICrudInteractor<Book> interactor)
        {
            _interactor = interactor;
        }

        [Route("")]
        public async Task<Book[]> GetAll()
        {
            var items = await _interactor.GetAllAsync();

            return items.Entity;
        }

    }
}
