using Xml.Content.Parser.Core.Domain.XmlContracts;

namespace Xml.Content.Parser.Tests.Common.Builders
{
    public class DescriptionDtoBuilder
    {
        private readonly string _description;

        public DescriptionDtoBuilder()
        {
            _description = "development team's project end celebration dinner";
        }

        public DescriptionDto Build()
        {
            return new DescriptionDto
            {
                Description = _description
            };
        }
    }
}