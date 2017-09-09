using System;
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
    public class LenderLogicTests
    {
        private LenderLogic _logic;
        private Mock<ILenderRepository> _lenderRepository;
        private Mock<ILogger> _logger;


        [TestInitialize]
        public void Setup()
        {
            _logger = new Mock<ILogger>();
            _logger.Setup(a => a.ForContext<LenderLogic>()).Returns(_logger.Object);

            _lenderRepository = new Mock<ILenderRepository>();

            _logic = new LenderLogic(_lenderRepository.Object, _logger.Object);
        }

        [TestMethod]
        public void ConstructorTests()
        {
            // ReSharper disable ObjectCreationAsStatement
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LenderLogic(null, null);
            });
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LenderLogic(_lenderRepository.Object, null);
            });
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        public async Task CreateAsync_lender_record_is_saved_to_repository()
        {
            _lenderRepository.Setup(a => a.CreateAsync(It.IsAny<Lender>()))
                .ReturnsAsync((Lender lender) =>
                {
                    lender.Id = 1;
                    return new OperationResult<Lender>(lender);
                });

            var result = await _logic.CreateAsync(new Lender());

            result.Success.Should().BeTrue();
            result.Entity.Should().BeAssignableTo<Lender>();
            result.Entity.Id.Should().NotBe(0);

            _logger.Verify(a=>a.Debug(It.IsAny<string>(), It.IsAny<Lender>()), Times.AtLeastOnce);
        }
    }
}
