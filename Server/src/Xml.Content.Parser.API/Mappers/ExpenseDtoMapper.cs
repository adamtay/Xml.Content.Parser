using System;
using Xml.Content.Parser.API.Contracts;
using Xml.Content.Parser.Core.Domain;

namespace Xml.Content.Parser.API.Mappers
{
    public static class ExpenseDtoMapper
    {
        public static ExpenseDto ToDto(this Expense expense)
        {
            if (expense == null) throw new ArgumentNullException(nameof(expense));

            return new ExpenseDto
            {
                CostCentre = expense.CostCentre,
                TotalInclGst = expense.TotalInclGst,
                TotalExclGst = expense.TotalExclGst,
                GstAmount = expense.GstAmount,
                Vendor = expense.Vendor,
                Description = expense.Description,
                EventDate = expense.EventDate
            };
        }
    }
}