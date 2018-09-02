using System;
using Xml.Content.Parser.Common.ExtensionMethods;

namespace Xml.Content.Parser.Core.Domain
{
    public class Expense
    {
        private readonly string _costCentre;
        private readonly decimal _total;
        private readonly decimal _gstAmount;
        private readonly string _vendor;
        private readonly string _description;
        private readonly string _dateEvent;

        public Expense(string costCentre, decimal total, string vendor, string description, string dateEvent)
        {
            if (total < 0) throw new ArgumentOutOfRangeException(nameof(total));
            if (string.IsNullOrWhiteSpace(vendor))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(vendor));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));
            if (string.IsNullOrWhiteSpace(dateEvent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(dateEvent));

            _costCentre = !string.IsNullOrWhiteSpace(costCentre) ? costCentre : "UNKNOWN";
            _total = total;
            _gstAmount = 0.15m; // TODO: Move gst into a configuration.
            _vendor = vendor;
            _description = description;
            _dateEvent = dateEvent;
        }

        public string CostCentre => _costCentre;

        public decimal TotalInclGst => _total.RoundToMoneyValue();

        public decimal TotalExclGst => (_total / (1 + _gstAmount)).RoundToMoneyValue();

        public decimal GstAmount => (_total - _total / (1 + _gstAmount)).RoundToMoneyValue();

        public string Vendor => _vendor;

        public string Description => _description;

        public string DateEvent => _dateEvent;
    }
}