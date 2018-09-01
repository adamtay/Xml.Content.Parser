using System;
using Xml.Content.Parser.Common;

namespace Xml.Content.Parser.Core.Domain
{
    public class ExpenseData
    {
        private readonly string _costCentre;
        private readonly decimal _total;
        private readonly decimal _gstAmount;

        public ExpenseData(string costCentre, decimal total)
        {
            if (total < 0) throw new ArgumentOutOfRangeException(nameof(total));

            _costCentre = !string.IsNullOrWhiteSpace(costCentre) ? costCentre : "UNKNOWN";
            _total = total;
            _gstAmount = 0.15m;
        }

        public string CostCentre => _costCentre;

        public decimal TotalInclGst => _total.RoundToMoneyValue();

        public decimal TotalExclGst => (_total / (1 + _gstAmount)).RoundToMoneyValue();

        public decimal GstAmount => (_total - _total / (1 + _gstAmount)).RoundToMoneyValue();
    }
}