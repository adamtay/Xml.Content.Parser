using FluentAssertions;
using NUnit.Framework;
using Xml.Content.Parser.Core.Domain;
using Xml.Content.Parser.Core.Domain.XmlContracts;
using Xml.Content.Parser.Core.Mappers;
using Xml.Content.Parser.Tests.Common.Builders;

namespace Xml.Content.Parser.Core.Tests.Domain
{
    [TestFixture]
    [Category("UnitTests")]
    [Category("Domain")]
    public class ExpenseDataTests
    {
        [Test]
        public void CanCalculateExpectedTotals()
        {
            ExpenseDto expenseDto = new ExpenseDto
            {
                Expense = new ExpenseDataDtoBuilder()
                    .WithCostCentre("DEV002")
                    .WithTotal(1024.01m)
                    .Build()
            };
            VendorDto vendorDto = new VendorDtoBuilder().Build();
            DescriptionDto descriptionDto = new DescriptionDtoBuilder().Build();
            EventDateDto eventDateDto = new EventDateDtoBuilder().Build();

            Expense expense = ExpenseMapper.Map(expenseDto, vendorDto, descriptionDto, eventDateDto);

            expense.CostCentre.Should().Be(expenseDto.Expense.CostCentre);
            expense.TotalInclGst.Should().Be(expenseDto.Expense.Total);
            expense.TotalExclGst.Should().Be(890.44m);
            expense.GstAmount.Should().Be(133.57m);
            expense.Vendor.Should().Be(vendorDto.Vendor);
            expense.Description.Should().Be(descriptionDto.Description);
            expense.EventDate.Should().Be(eventDateDto.Date);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void MissingCostCentreDefaultsToUnknown(string costCentre)
        {
            ExpenseDto expenseDto = new ExpenseDto
            {
                Expense = new ExpenseDataDtoBuilder()
                    .WithCostCentre(costCentre)
                    .WithTotal(1024.01m)
                    .Build()
            };
            VendorDto vendorDto = new VendorDtoBuilder().Build();
            DescriptionDto descriptionDto = new DescriptionDtoBuilder().Build();
            EventDateDto eventDateDto = new EventDateDtoBuilder().Build();

            Expense expense = ExpenseMapper.Map(expenseDto, vendorDto, descriptionDto, eventDateDto);

            expense.CostCentre.Should().Be("UNKNOWN");
        }
    }
}