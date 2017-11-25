using System.Linq;
using Vault.Core.Entities;
using Vault.DataBase;

namespace Vault.UI.Admin.Infrastructure
{
    public class DatabaseSeed
    {
        public static void Seed(DataContext db)
        {
            if (!db.Books.Any())
            {
                SeedBooks(db);
            }

            if (!db.Lenders.Any())
            {
                SeedLenders(db);
            }
        }

        private static void SeedLenders(DataContext db)
        {
            db.Lenders.AddRange(
                new Lender { Email = "tuvigur@cars2.club", Name = "John Smith" },
                new Lender { Email = "jaxufeh@nada.email", Name = "Pierre Jean Jacques" },
                new Lender { Email = "bipaf@wmail.club", Name = "Juan Pérez" },
                new Lender { Email = "xefisugo@banit.club", Name = "Jan Novák" },
                new Lender { Email = "sezocoki@banit.club", Name = "Max Mustermann" }
                );

            db.SaveChanges();
        }

        private static void SeedBooks(DataContext db)
        {
            db.Books.AddRange(
                new Book { Author = "Kalle Muuli, Helen Sulg", Name = "Reketiga tüdruk. Kaia Kanepi teekond Ameerika mägedel", IsAvailable = true },
                new Book { Author = "Jesper Parve", Name = "Mees. Otse ja ausalt", IsAvailable = true },
                new Book { Author = "Peeter Ernits", Name = "Viimane rüütel. Arnold Rüütli jäljed Eesti pinnal ja ajas", IsAvailable = true },
                new Book { Author = "Indrek Hargla", Name = "Merivälja", IsAvailable = true },
                new Book { Author = "Mihkel Raud", Name = "Eestlase käsiraamat. 100 asja, mida õige eestlane teeb", IsAvailable = true },
                new Book { Author = "Toomas Sulling", Name = "Südamega südamest. Südamekirurgi poole sajandi töö kogemus", IsAvailable = true },
                new Book { Author = "MJ DeMarco", Name = "Miljonäri kiirtee", IsAvailable = true },
                new Book { Author = "Ilmar Tomusk", Name = "Isamoodi unejutud", IsAvailable = true },
                new Book { Author = "Riin Tuttelberg", Name = "Tom õpib rahamängu", IsAvailable = true },
                new Book { Author = "Aleksandr Šeps", Name = "Meedium. Otsides elu mõtet", IsAvailable = true }
                );

            db.SaveChanges();
        }
    }
}
