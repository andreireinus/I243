using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core.Tests
{
    [TestClass]
    public class ReminderTests
    {
        private Reminder _reminder;
        private Mock<ILogger> _logger;
        private Mock<ILendingRecordRepository> _repository;
        private Mock<INotifier> _notifier;

        [TestInitialize]
        public void Setup()
        {
            _logger = new Mock<ILogger>();
            _logger.Setup(a => a.ForContext<Reminder>()).Returns(_logger.Object);

            _repository = new Mock<ILendingRecordRepository>();
            _notifier = new Mock<INotifier>();

            _reminder = new Reminder(_repository.Object, _notifier.Object, _logger.Object);
        }

        [TestMethod]
        public void ConstructorTests()
        {
            // ReSharper disable ObjectCreationAsStatement
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new Reminder(null, null, null);
            });
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new Reminder(_repository.Object, null, null);
            });
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new Reminder(_repository.Object, _notifier.Object, null);
            });
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        public async Task When_there_are_no_late_book_no_notification_is_sent()
        {
            var result = await _reminder.SendNotifications();
            result.Success.Should().BeTrue();
            _notifier.Verify(a => a.SendAsync(It.IsAny<Lender>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public async Task With_late_books_notification_is_sent_out()
        {
            _repository.Setup(a => a.GetAllLateAsync()).ReturnsAsync(new[]
            {
                new LendingRecord
                {
                    From = DateTime.Now.AddDays(-30),
                    To = DateTime.Now.AddDays(-2),
                    LibraryItem = new LibraryItem {Name = "BOOK1"},
                    Lender = new Lender {Name = "John Doe", Email = "john.doe@gmail.com"}
                }
            });

            var result = await _reminder.SendNotifications();
            result.Success.Should().BeTrue();
            _notifier.Verify(a => a.SendAsync(It.IsAny<Lender>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
