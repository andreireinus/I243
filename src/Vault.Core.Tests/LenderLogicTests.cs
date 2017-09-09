using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core.Tests
{
    [TestClass]
    public class LenderLogicTests
    {
        private LenderLogic _logic;
        private Mock<ILenderRepository> _lenderRepository;


        [TestInitialize]
        public void Setup()
        {
            _lenderRepository = new Mock<ILenderRepository>();
            _logic = new LenderLogic(_lenderRepository.Object);
        }

        [TestMethod]
        public void ConstructorTests()
        {
            // ReSharper disable ObjectCreationAsStatement
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LenderLogic(null);
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
        }
    }
}
