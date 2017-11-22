using Vault.Core.Entities;

namespace Vault.DataBase.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(DataContext context) : base(context)
        {
        }
    }
}
