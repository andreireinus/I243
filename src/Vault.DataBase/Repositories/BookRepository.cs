using System.Linq;
using Microsoft.EntityFrameworkCore;
using Vault.Core.Entities;

namespace Vault.DataBase.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(DataContext context) : base(context)
        {
        }

        public override IQueryable<Book> Query()
        {
            return base.Query()
                .Include(a => a.Location)
                .AsNoTracking();
        }
    }
}
