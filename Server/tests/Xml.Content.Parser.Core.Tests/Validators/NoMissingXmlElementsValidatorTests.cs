using FluentAssertions;
using NUnit.Framework;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Tests.Common;

namespace Xml.Content.Parser.Core.Tests.Validators
{
    [TestFixture]
    [Category("UnitTests")]
    [Category("XmlValidation")]
    public class NoMissingXmlElementsValidatorTests : TestBase
    {
        [Test]
        [TestCase("<test1></test1><test2></test2>")]
        [TestCase("<test></TEST>")]
        public void MessageContentWithMatchingXmlElementDoesNotThrowException(string messageContent)
        {
            Assert.DoesNotThrow(() => NoMissingXmlElementsValidator.Validate(messageContent));
        }

        [Test]
        public void MessageContentWithMismatchingXmlElementsThrowsException()
        {
            const string messageContent = "<test1></test2>";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                NoMissingXmlElementsValidator.Validate(messageContent);
            });

            exception.Message.Should()
                .Be("The specified message content contains XML elements without it's corresponding pair.");
        }

        [Test]
        public void MessageContentWithUnevenMatchingXmlElementsThrowsException()
        {
            const string messageContent = "<test1></test1><test1></test2>";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                NoMissingXmlElementsValidator.Validate(messageContent);
            });

            exception.Message.Should()
                .Be("The specified message content contains XML elements without it's corresponding pair.");
        }

        [Test]
        public void MessageContentWithNoClosingXmlElementsThrowsException()
        {
            const string messageContent = "<test1><test2>";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                NoMissingXmlElementsValidator.Validate(messageContent);
            });

            exception.Message.Should()
                .Be("The specified message content contains XML elements without it's corresponding pair.");
        }

        [Test]
        public void MessageContentWithNoOpeningXmlElementsThrowsException()
        {
            const string messageContent = "</test1></test2>";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                NoMissingXmlElementsValidator.Validate(messageContent);
            });

            exception.Message.Should()
                .Be("The specified message content contains XML elements without it's corresponding pair.");
        }
    }
}