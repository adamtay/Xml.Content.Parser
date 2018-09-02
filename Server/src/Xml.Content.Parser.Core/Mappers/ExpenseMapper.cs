using System;
using Xml.Content.Parser.Core.Domain;

namespace Xml.Content.Parser.Core.Mappers
{
    public static class ExpenseMapper
    {
        public static Expense Map(ExpenseDto expenseDto, VendorDto vendorDto, DescriptionDto descriptionDto, DateEventDto dateEventDto)
        {
            if (expenseDto == null) throw new ArgumentNullException(nameof(expenseDto));
            if (vendorDto == null) throw new ArgumentNullException(nameof(vendorDto));
            if (descriptionDto == null) throw new ArgumentNullException(nameof(descriptionDto));
            if (dateEventDto == null) throw new ArgumentNullException(nameof(dateEventDto));

            return new Expense(
                expenseDto.Expense.CostCentre,
                expenseDto.Expense.Total,
                vendorDto.Vendor,
                descriptionDto.Description,
                dateEventDto.Date);
        }
    }
}