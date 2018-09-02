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
        [TestCase("<test_element></test_element>")]
        [TestCase("<123></123>")]
        public void MessageContentWithXmlElementsDoesNotThrowException(string messageContent)
        {
            Assert.DoesNotThrow(() => ContainsXmlElementsValidator.Validate(messageContent));
        }

        [Test]
        [TestCase("hello world")]
        [TestCase("<bad xml></bad xml>")]
        [TestCase("<aB1@#></aB1@#>")]
        public void MessageContentWithInvalidXmlElementThrowsException(string messageContent)
        {
            AssertXmlContentParserExceptionIsThrown(messageContent);
        }

        [Test]
        public void MessageContentWithoutClosingXmlElementsThrowsException()
        {
            const string messageContent = "<test><test>";

            AssertXmlContentParserExceptionIsThrown(messageContent);
        }
        
        [Test]
        public void MessageContentWithoutOpeningXmlElementsThrowsException()
        {
            const string messageContent = "</test></test>";

            AssertXmlContentParserExceptionIsThrown(messageContent);
        }

        private void AssertXmlContentParserExceptionIsThrown(string messageContent)
        {
            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                ContainsXmlElementsValidator.Validate(messageContent);
            });

            exception.Message.Should().Be("The specified message content does not contain any valid XML elements.");
        }
    }
}