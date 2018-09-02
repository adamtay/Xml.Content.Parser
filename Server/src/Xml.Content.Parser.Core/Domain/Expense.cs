using System;
using Xml.Content.Parser.Common.ExtensionMethods;

namespace Xml.Content.Parser.Core.Domain
{
    /// <summary>
    /// Represents the <see cref="Expense" /> domain <see cref="object"/>.
    /// </summary>
    public class Expense
    {
        private readonly string _costCentre;
        private readonly decimal _total;
        private readonly decimal _gstAmount;
        private readonly string _vendor;
        private readonly string _description;
        private readonly string _eventDate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="costCentre">The cost centre.</param>
        /// <param name="total">The total.</param>
        /// <param name="vendor">The vendor.</param>
        /// <param name="description">The description.</param>
        /// <param name="eventDate">The event date.</param>
        /// <exception cref="ArgumentOutOfRangeException">total</exception>
        /// <exception cref="ArgumentNullException">
        /// vendor
        /// or
        /// description
        /// or
        /// eventDate
        /// </exception>
        public Expense(string costCentre, decimal total, string vendor, string description, string eventDate)
        {
            if (total < 0) throw new ArgumentOutOfRangeException(nameof(total));
            if (vendor == null) throw new ArgumentNullException(nameof(vendor));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (eventDate == null) throw new ArgumentNullException(nameof(eventDate));

            _costCentre = !string.IsNullOrWhiteSpace(costCentre) ? costCentre : "UNKNOWN";
            _total = total;
            _gstAmount = 0.15m; // TODO: Move gst into a configuration.
            _vendor = vendor;
            _description = description;
            _eventDate = eventDate;
        }

        /// <summary>
        /// Gets the cost centre.
        /// </summary>
        /// <value>
        /// The cost centre.
        /// </value>
        public string CostCentre => _costCentre;

        /// <summary>
        /// Gets the total incl GST.
        /// </summary>
        /// <value>
        /// The total incl GST.
        /// </value>
        public decimal TotalInclGst => _total.RoundToMoneyValue();

        /// <summary>
        /// Gets the total excl GST.
        /// </summary>
        /// <value>
        /// The total excl GST.
        /// </value>
        public decimal TotalExclGst => (_total / (1 + _gstAmount)).RoundToMoneyValue();

        /// <summary>
        /// Gets the GST amount.
        /// </summary>
        /// <value>
        /// The GST amount.
        /// </value>
        public decimal GstAmount => (_total - _total / (1 + _gstAmount)).RoundToMoneyValue();

        /// <summary>
        /// Gets the vendor.
        /// </summary>
        /// <value>
        /// The vendor.
        /// </value>
        public string Vendor => _vendor;

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description => _description;

        /// <summary>
        /// Gets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        public string EventDate => _eventDate;
    }
}