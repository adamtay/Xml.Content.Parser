using Xml.Content.Parser.Core.Domain.XmlContracts;

namespace Xml.Content.Parser.Tests.Common.Builders
{
    public class VendorDtoBuilder
    {
        private readonly string _vendor;

        public VendorDtoBuilder()
        {
            _vendor = "Viaduct Steakhouse";
        }

        public VendorDto Build()
        {
            return new VendorDto
            {
                Vendor = _vendor
            };
        }
    }
}