using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core.Tests
{
    [TestClass]
    public class StockHandlingTests
    {
        private StockHandling _handling;
        private Mock<ILibraryItemRepository> _repository;
        private LibraryItem _item;
        private byte[] _validBytes = { 1, 2, 3, 4, 6 };

        [TestInitialize]
        public void Setup()
        {
            _repository = new Mock<ILibraryItemRepository>();

            _handling = new StockHandling(_repository.Object);

            _item = new LibraryItem
            {
            };
        }

        [TestMethod]
        public async Task AddImageAsync_throws_exception_when_input_item_is_null()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
            {
                await _handling.AddImageAsync(null, new byte[] { 1 });
            });
        }

        [TestMethod]
        public async Task AddImageAsync_throws_exception_when_input_bytes_are_null()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
                {
                    await _handling.AddImageAsync(_item, null);
                });
        }

        [TestMethod]
        public async Task AddImageAsync_throws_exception_when_input_bytes_are_empty()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
            {
                await _handling.AddImageAsync(_item, new byte[] { });
            });
        }


        [TestMethod]
        public async Task AddImageAsync_when_item_is_not_found_in_repository_error_returned()
        {
            // Arrange
            _repository.Setup(a => a.GetAsync(It.IsAny<int>())).ReturnsAsync(new OperationResult<LibraryItem>((LibraryItem)null));

            // Act
            var result = await _handling.AddImageAsync(_item, _validBytes);

            // Assert
            result.Success.Should().BeFalse();
        }

        [TestMethod]
        public async Task AddImageAsync_when_item_is_found_in_repository_then_picture_is_added_and_saved()
        {
            // Arrange
            _repository.Setup(a => a.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(new OperationResult<LibraryItem>(_item));
            _repository.Setup(a => a.UpdateAsync(It.IsAny<LibraryItem>()))
                .ReturnsAsync((LibraryItem item) => new OperationResult<LibraryItem>(item));

            // Act
            var result = await _handling.AddImageAsync(_item, _validBytes);

            // Assert
            result.Success.Should().BeTrue();
            result.Entity.Pictures.Should().NotBeEmpty();
            result.Entity.Pictures.First().Bytes.ShouldAllBeEquivalentTo(_validBytes);
        }

    }
}
