using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Core.Validators;
using Xml.Content.Parser.Tests.Common;

namespace Xml.Content.Parser.Core.Tests.Factories
{
    [TestFixture]
    [Category("UnitTests")]
    [Category("XmlValidation")]
    public class XmlValidationFactoryTests : TestBase
    {
        [Test]
        public void FactoryReturnsValidationInCorrectOrder()
        {
            IEnumerable<IXmlElementValidator> xmlElementValidators = XmlValidationFactory.CreateValidators().ToList();

            xmlElementValidators.Count().Should().Be(4);

            xmlElementValidators.ElementAt(0).Should().BeOfType<ContainsXmlElementsValidator>();
            xmlElementValidators.ElementAt(1).Should().BeOfType<NoMissingXmlElementsValidator>();
            xmlElementValidators.ElementAt(2).Should().BeOfType<ValidXmlElementsValidator>();
            xmlElementValidators.ElementAt(3).Should().BeOfType<MandatoryXmlElementsValidator>();
        }
    }
}