using System;
using Xml.Content.Parser.API.Contracts;
using Xml.Content.Parser.Core.Domain;

namespace Xml.Content.Parser.API.Mappers
{
    /// <summary>
    /// Responsible for mapping between <see cref="Expense"/> and <see cref="ExpenseDto"/>.
    /// </summary>
    public static class ExpenseDtoMapper
    {
        /// <summary>
        /// Maps from the <see cref="Expense"/> <see cref="object"/> to <see cref="ExpenseDto"/> <see cref="object"/>.
        /// </summary>
        /// <param name="expense">The expense.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">expense</exception>
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