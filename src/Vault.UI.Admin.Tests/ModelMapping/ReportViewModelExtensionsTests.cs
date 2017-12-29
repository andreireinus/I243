using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vault.Core;
using Vault.UI.Admin.ModelMapping;

namespace Vault.UI.Admin.Tests.ModelMapping
{
    [TestClass]
    public class ReportViewModelExtensionsTests
    {
        [TestMethod]
        public void ToViewModel_Single_row_mapping()
        {
            var row = new ReportInteractor.Row
            {
                Author = "author"
            };

            var result = row.ToViewModel();

            result.Author.Should().Be("author");
        }
    }
}
