using System;
using Xml.Content.Parser.Core.Domain;

namespace Xml.Content.Parser.Core.Mappers
{
    public static class ExpenseDataDtoMapper
    {
        public static ExpenseData ToDomain(this ExpenseDataDto expenseDataDto)
        {
            if (expenseDataDto == null) throw new ArgumentNullException(nameof(expenseDataDto));

            return new ExpenseData(
                expenseDataDto.CostCentre,
                expenseDataDto.Total);
        }
    }
}