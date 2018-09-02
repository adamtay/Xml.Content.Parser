using FluentAssertions;
using NUnit.Framework;
using Xml.Content.Parser.Core.Domain;
using Xml.Content.Parser.Core.Mappers;
using Xml.Content.Parser.Tests.Common.Builders;

namespace Xml.Content.Parser.Core.Tests.Domain
{
    [TestFixture]
    [Category("UnitTests")]
    [Category("Domain")]
    public class ExpenseDataTests
    {
        //[Test]
        //public void CanCalculateExpectedTotals()
        //{
        //    ExpenseDataDto expenseDataDto = new ExpenseDataDtoBuilder()
        //        .WithCostCentre("DEV002")
        //        .WithTotal(1024.01m)
        //        .Build();

        //    Expense expense = expenseDataDto.ToDomain();

        //    expense.CostCentre.Should().Be(expenseDataDto.CostCentre);
        //    expense.TotalInclGst.Should().Be(expenseDataDto.Total);
        //    expense.TotalExclGst.Should().Be(890.44m);
        //    expense.GstAmount.Should().Be(133.57m);
        //}

        //[Test]
        //[TestCase(null)]
        //[TestCase("")]
        //[TestCase(" ")]
        //public void MissingCostCentreDefaultsToUnknown(string costCentre)
        //{
        //    ExpenseDataDto expenseDataDto = new ExpenseDataDtoBuilder()
        //        .WithCostCentre(costCentre)
        //        .Build();

        //    Expense expense = expenseDataDto.ToDomain();

        //    expense.CostCentre.Should().Be("UNKNOWN");
        //}
    }
}