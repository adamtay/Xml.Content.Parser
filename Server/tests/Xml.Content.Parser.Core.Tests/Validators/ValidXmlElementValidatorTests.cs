using FluentAssertions;
using NUnit.Framework;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Tests.Common;

namespace Xml.Content.Parser.Core.Tests.Validators
{
    [TestFixture]
    [Category("UnitTests")]
    [Category("XmlValidation")]
    public class ValidXmlElementValidatorTests : TestBase
    {
        [Test]
        [TestCase("<test>")]
        [TestCase("<TEST>")]
        [TestCase("<test_123>")]
        [TestCase("</test>")]
        [TestCase("</TEST>")]
        [TestCase("</test_123>")]
        public void ValidXmlElementDoesNotThrowException(string xmlElement)
        {
            Assert.DoesNotThrow(() => ValidXmlElementsValidator.Validate(xmlElement));
        }

        [Test]
        [TestCase("hello world")]
        [TestCase("<test />")]
        [TestCase("<test")]
        [TestCase("test>")]
        [TestCase("<te st>")]
        [TestCase("</test")]
        [TestCase("/test>")]
        [TestCase("<//test>")]
        [TestCase("</te /st>")]
        [TestCase("<  test  >")]
        [TestCase("<  /  test  >")]
        public void InvalidXmlElementThrowsException(string xmlElement)
        {
            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                ValidXmlElementsValidator.Validate(xmlElement);
            });

            exception.Message.Should().Be("The specified message contains invalid XML syntax.");
        }
    }
}