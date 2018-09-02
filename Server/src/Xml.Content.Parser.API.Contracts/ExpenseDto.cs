namespace Xml.Content.Parser.API.Contracts
{
    public class ExpenseDto
    {
        public string CostCentre { get; set; }

        public decimal TotalInclGst { get; set; }

        public decimal TotalExclGst { get; set; }

        public decimal GstAmount { get; set; }

        public string Vendor { get; set; }

        public string Description { get; set; }

        public string EventDate { get; set; }
    }
}