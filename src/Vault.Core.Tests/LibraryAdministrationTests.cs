using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core.Tests
{
    [TestClass]
    public class LibraryAdministrationTests
    {
        private LibraryAdministration _admin;
        private Mock<ILibraryItemRepository> _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new Mock<ILibraryItemRepository>();
            _admin = new LibraryAdministration(_repository.Object);
        }

        [TestMethod]
        public void ConstructorTests()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                // ReSharper disable ObjectCreationAsStatement
                new LibraryAdministration(null);
                // ReSharper restore ObjectCreationAsStatement
            });
        }

        [TestMethod]
        public async Task Add_book_to_library_saves_to_repository()
        {
            var libraryItem = new LibraryItem();

            _repository.Setup(a => a.CreateAsync(It.IsAny<LibraryItem>())).ReturnsAsync(() =>
            {
                libraryItem.Id = 1;
                return new OperationResult<LibraryItem>(libraryItem);
            });

            var result = await _admin.AddAsync(libraryItem);

            result.Success.Should().BeTrue();
            result.Entity.Should().BeAssignableTo<LibraryItem>();
            result.Entity.Id.Should().NotBe(0);
        }
    }
}
