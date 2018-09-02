using Xml.Content.Parser.Core.Domain.XmlContracts;

namespace Xml.Content.Parser.Tests.Common.Builders
{
    public class EventDateDtoBuilder
    {
        private readonly string _date;

        public EventDateDtoBuilder()
        {
            _date = "Tuesday 27 April 2017";
        }

        public EventDateDto Build()
        {
            return new EventDateDto
            {
                Date = _date
            };
        }
    }
}