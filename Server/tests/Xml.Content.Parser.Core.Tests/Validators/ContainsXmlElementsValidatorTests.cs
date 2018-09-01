using FluentAssertions;
using NUnit.Framework;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Tests.Common;

namespace Xml.Content.Parser.Core.Tests.Validators
{
    [TestFixture]
    [Category("UnitTests")]
    [Category("XmlValidation")]
    public class ContainsXmlElementsValidatorTests : TestBase
    {
        [Test]
        [TestCase("<test></test>")]
        [TestCase("<TEST></TEST>")]
        public void MessageContentWithXmlElementsDoesNotThrowException(string messageContent)
        {
            Assert.DoesNotThrow(() => ContainsXmlElementsValidator.Validate(messageContent));
        }

        [Test]
        public void MessageContentWithoutXmlElementsThrowsException()
        {
            const string messageContent = "hello world";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                ContainsXmlElementsValidator.Validate(messageContent);
            });

            exception.Message.Should().Be("The specified message content does not contain any valid XML elements.");
        }

        [Test]
        public void MessageContentWithNoClosingXmlElementsThrowsException()
        {
            const string messageContent = "<test><test>";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                ContainsXmlElementsValidator.Validate(messageContent);
            });

            exception.Message.Should().Be("The specified message content does not contain any valid XML elements.");
        }
        
        [Test]
        public void MessageContentWithNoOpeningXmlElementsThrowsException()
        {
            const string messageContent = "</test></test>";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                ContainsXmlElementsValidator.Validate(messageContent);
            });

            exception.Message.Should().Be("The specified message content does not contain any valid XML elements.");
        }
    }
}