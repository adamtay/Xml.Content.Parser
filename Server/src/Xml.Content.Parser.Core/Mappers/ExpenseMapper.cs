using System;
using Xml.Content.Parser.Core.Domain;
using Xml.Content.Parser.Core.Domain.XmlContracts;

namespace Xml.Content.Parser.Core.Mappers
{
    public static class ExpenseMapper
    {
        public static Expense Map(ExpenseDto expenseDto, VendorDto vendorDto, DescriptionDto descriptionDto, EventDateDto eventDateDto)
        {
            if (expenseDto == null) throw new ArgumentNullException(nameof(expenseDto));

            return new Expense(
                expenseDto.Expense.CostCentre ?? string.Empty,
                expenseDto.Expense.Total,
                vendorDto?.Vendor ?? string.Empty,
                descriptionDto?.Description ?? string.Empty,
                eventDateDto?.Date ?? string.Empty);
        }
    }
}