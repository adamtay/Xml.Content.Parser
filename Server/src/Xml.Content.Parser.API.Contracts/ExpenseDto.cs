namespace Xml.Content.Parser.API.Contracts
{
    /// <summary>
    /// Represents an <see cref="ExpenseDto"/> <see cref="object"/>.
    /// </summary>
    public class ExpenseDto
    {
        /// <summary>
        /// Gets or sets the cost centre.
        /// </summary>
        /// <value>
        /// The cost centre.
        /// </value>
        public string CostCentre { get; set; }

        /// <summary>
        /// Gets or sets the total incl GST.
        /// </summary>
        /// <value>
        /// The total incl GST.
        /// </value>
        public decimal TotalInclGst { get; set; }

        /// <summary>
        /// Gets or sets the total excl GST.
        /// </summary>
        /// <value>
        /// The total excl GST.
        /// </value>
        public decimal TotalExclGst { get; set; }

        /// <summary>
        /// Gets or sets the GST amount.
        /// </summary>
        /// <value>
        /// The GST amount.
        /// </value>
        public decimal GstAmount { get; set; }

        /// <summary>
        /// Gets or sets the vendor.
        /// </summary>
        /// <value>
        /// The vendor.
        /// </value>
        public string Vendor { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        public string EventDate { get; set; }
    }
}