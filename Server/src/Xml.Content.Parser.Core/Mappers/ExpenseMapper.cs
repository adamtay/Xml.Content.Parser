using System;
using Xml.Content.Parser.Core.Domain;
using Xml.Content.Parser.Core.Domain.XmlContracts;

namespace Xml.Content.Parser.Core.Mappers
{
    /// <summary>
    /// Responsible for initializing an instance of an <see cref="Expense"/> <see cref="object"/>.
    /// </summary>
    public static class ExpenseMapper
    {
        /// <summary>
        /// Initializes an <see cref="Expense"/> <see cref="object"/>.
        /// </summary>
        /// <param name="expenseDto">The expense dto.</param>
        /// <param name="vendorDto">The vendor dto.</param>
        /// <param name="descriptionDto">The description dto.</param>
        /// <param name="eventDateDto">The event date dto.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">expenseDto</exception>
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