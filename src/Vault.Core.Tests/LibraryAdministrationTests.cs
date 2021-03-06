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
        private Mock<ILibraryItemRepository> _libraryRepository;
        private Mock<ILendingRecordRepository> _lendingRepository;

        [TestInitialize]
        public void Setup()
        {
            _libraryRepository = new Mock<ILibraryItemRepository>();
            _lendingRepository = new Mock<ILendingRecordRepository>();
            _admin = new LibraryAdministration(_libraryRepository.Object, _lendingRepository.Object);
        }

        [TestMethod]
        public void ConstructorTests()
        {
            // ReSharper disable ObjectCreationAsStatement
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LibraryAdministration(null, null);
            });
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LibraryAdministration(_libraryRepository.Object, null);
            });
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        public async Task Add_book_to_library_saves_to_repository()
        {
            var libraryItem = new Book();

            _libraryRepository.Setup(a => a.CreateAsync(It.IsAny<Book>())).ReturnsAsync(() =>
            {
                libraryItem.Id = 1;
                return new OperationResult<Book>(libraryItem);
            });

            var result = await _admin.AddAsync(libraryItem);

            result.Success.Should().BeTrue();
            result.Entity.Should().BeAssignableTo<Book>();
            result.Entity.Id.Should().NotBe(0);
        }

        [TestMethod]
        public async Task Checkout_when_lending_out_available_item_then_lending_record_is_created_for_lender()
        {
            _lendingRepository.Setup(a => a.CreateAsync(It.IsAny<LendingRecord>()))
                .ReturnsAsync((LendingRecord a) => new OperationResult<LendingRecord>(a));

            var lender = new Lender();
            var item = new Book();
            var to = DateTime.Now.AddDays(14);

            var result = await _admin.CheckoutAsync(lender, item, to);

            result.Success.Should().BeTrue();
            result.Entity.Should().BeAssignableTo<LendingRecord>();
            result.Entity.From.Should().BeSameDateAs(DateTime.Now);
            result.Entity.To.Should().BeSameDateAs(to);
            result.Entity.Book.Should().Be(item);
            result.Entity.Lender.Should().Be(lender);

            _lendingRepository.Verify(a => a.CreateAsync(It.IsAny<LendingRecord>()), Times.Once);
        }

        [TestMethod]
        public async Task AvailableItems_return_data_from_repository()
        {
            await _admin.AvailableItemsAsync();
            _libraryRepository.Verify(a => a.AvailableItemsAsync(), Times.Once);
        }
    }
}
