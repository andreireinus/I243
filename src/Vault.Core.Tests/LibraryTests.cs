using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core.Tests
{
    [TestClass]
    public class LibraryTests
    {
        private Library _library;
        private Mock<IBookRepository> _bookRepository;

        [TestInitialize]
        public void Setup()
        {
            _bookRepository = new Mock<IBookRepository>();
            _library = new Library(_bookRepository.Object);
        }


        [TestMethod]
        public async Task Add_book_to_library_saves_to_repository()
        {
            var book = new Book();

            _bookRepository.Setup(a => a.CreateAsync(It.IsAny<Book>())).ReturnsAsync(() =>
            {
                book.Id = 1;
                return new OperationResult<Book>(book);
            });

            var result = await _library.AddAsync(book);

            result.Success.Should().BeTrue();
            result.Entity.Should().BeAssignableTo<Book>();
            result.Entity.Id.Should().NotBe(0);
        }
    }
}
