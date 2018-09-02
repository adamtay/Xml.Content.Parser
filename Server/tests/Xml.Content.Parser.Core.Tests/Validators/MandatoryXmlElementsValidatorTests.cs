using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Tests.Common;

namespace Xml.Content.Parser.Core.Tests.Validators
{
    [TestFixture]
    [Category("UnitTests")]
    [Category("XmlValidation")]
    public class MandatoryXmlElementsValidatorTests : TestBase
    {
        [Test]
        [TestCase("<test>hello</test>")]
        [TestCase("<TEST>hello</test>")]
        public void MessageContentWithMandatoryXmlElementsDoesNotThrowException(string messageContent)
        {
            List<string> mandatoryXmlElements = new List<string>
            {
                "<test>"
            };

            ValidationRepository.GetMandatoryXmlElements().Returns(mandatoryXmlElements);

            Assert.DoesNotThrow(() => MandatoryXmlElementsValidator.Validate(messageContent));
        }

        [Test]
        [TestCase("<test1><test2>hello</test2></test1>")]
        [TestCase("<test1>hello</test1><test2>hello</test2>")]
        public void MessageContentWithMultipleManadtoryXmlElementsDoesNotThrowException(string messageContent)
        {
            List<string> mandatoryXmlElements = new List<string>
            {
                "<test1>",
                "<test2>"
            };

            ValidationRepository.GetMandatoryXmlElements().Returns(mandatoryXmlElements);

            Assert.DoesNotThrow(() => MandatoryXmlElementsValidator.Validate(messageContent));
        }

        [Test]
        [TestCase("<test1>hello</test1>")]
        [TestCase("hello world")]
        public void MessageContentWithMissingMandatoryXmlElementsThrowsException(string messageContent)
        {
            List<string> mandatoryXmlElements = new List<string>
            {
                "<test1>",
                "<test2>"
            };

            ValidationRepository.GetMandatoryXmlElements().Returns(mandatoryXmlElements);

            AssertXmlContentParserExceptionIsThrown(messageContent, mandatoryXmlElements);
        }

        [Test]
        public void MessageContentWithNoContentForMandatoryXmlElementThrowsException()
        {
            List<string> mandatoryXmlElements = new List<string>
            {
                "<test>"
            };

            ValidationRepository.GetMandatoryXmlElements().Returns(mandatoryXmlElements);

            const string messageContent = "<test></test>";

            AssertXmlContentParserExceptionIsThrown(messageContent, mandatoryXmlElements);
        }

        private void AssertXmlContentParserExceptionIsThrown(string messageContent, List<string> mandatoryXmlElements)
        {
            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                MandatoryXmlElementsValidator.Validate(messageContent);
            });

            exception.Message.Should()
                .Be($"The specified message content does not contain all mandatory XML elements. Mandatory elements: '{string.Join(",", mandatoryXmlElements)}'.");
        }
    }
}