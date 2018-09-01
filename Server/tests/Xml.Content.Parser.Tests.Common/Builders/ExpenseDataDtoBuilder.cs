using Xml.Content.Parser.Core.Domain;

namespace Xml.Content.Parser.Tests.Common.Builders
{
    public class ExpenseDataDtoBuilder
    {
        private string _costCentre;
        private decimal _total;

        public ExpenseDataDtoBuilder()
        {
            _costCentre = "DEV002";
            _total = 1024.01m;
        }

        public ExpenseDataDto Build()
        {
            return new ExpenseDataDto
            {
                CostCentre = _costCentre,
                Total = _total
            };
        }

        public ExpenseDataDtoBuilder WithCostCentre(string costCentre)
        {
            _costCentre = costCentre;
            return this;
        }

        public ExpenseDataDtoBuilder WithTotal(decimal total)
        {
            _total = total;
            return this;
        }
    }
}