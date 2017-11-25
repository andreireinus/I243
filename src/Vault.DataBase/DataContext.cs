using System;
using Microsoft.EntityFrameworkCore;
using Vault.Core.Entities;

namespace Vault.DataBase
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Lender> Lenders { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}
