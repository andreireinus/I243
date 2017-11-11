﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Vault.Core;
using Vault.Core.Entities;
using Vault.UI.AdminRestApi.Infrastructure;

namespace Vault.UI.AdminRestApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : CrudController<Book>
    {
        public BookController(ICrudInteractor<Book> interactor) : base(interactor)
        {
        }

        [SwaggerOperation("BookCreate")]
        public override Task<Book> Create(Book entity)
        {
            return base.Create(entity);
        }

        [SwaggerOperation("BookUpdate")]
        public override Task<Book> Update(int id, Book entity)
        {
            return base.Update(id, entity);
        }

        [SwaggerOperation("BookGetAll")]
        public override Task<Book[]> GetAll()
        {
            return base.GetAll();
        }

        [SwaggerOperation("BookGet")]
        public override Task<Book> Get(int id)
        {
            return base.Get(id);
        }
    }
}
