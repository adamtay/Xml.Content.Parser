﻿using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class CostCentreDto
    {
        [JsonProperty(ExpenseConstants.CostCentre)]
        public string CostCentre { get; set; }
    }
}