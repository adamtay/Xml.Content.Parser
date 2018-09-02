using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Xml.Content.Parser.Common;
using Xml.Content.Parser.Tests.Common;

namespace Xml.Content.Parser.Core.Tests.Services
{
    [TestFixture]
    [Category("UnitTests")]
    [Category("XmlValidation")]
    public class IdentifyXmlElementsServiceTests : TestBase
    {
        [Test]
        [TestCase("<test1><test2>")]
        [TestCase("<TEST1><TEST2>")]
        public void CanIdentifyXmlOpeningElementsFromMessageContent(string messageContent)
        {
            IEnumerable<string> xmlElements = IdentifyXmlElementsService.IdentifyXmlElements(messageContent, RegularExpressions.XmlOpenElementRegex).ToList();

            xmlElements.Should().Contain("<test1>");
            xmlElements.Should().Contain("<test2>");
        }

        [Test]
        [TestCase("</test1></test2>")]
        [TestCase("</TEST1></TEST2>")]
        public void CanIdentifyXmlClosingElementsFromMessageContent(string messageContent)
        {
            IEnumerable<string> xmlElements = IdentifyXmlElementsService.IdentifyXmlElements(messageContent, RegularExpressions.XmlCloseElementRegex).ToList();

            xmlElements.Should().Contain("</test1>");
            xmlElements.Should().Contain("</test2>");
        }

        [Test]
        public void MessageContentWithNoXmlElementsReturnsEmptyList()
        {
            const string messageContent = "hello world";

            IEnumerable<string> xmlOpeningElements = IdentifyXmlElementsService.IdentifyXmlElements(messageContent, RegularExpressions.XmlOpenElementRegex).ToList();
            IEnumerable<string> xmlClosingElements = IdentifyXmlElementsService.IdentifyXmlElements(messageContent, RegularExpressions.XmlCloseElementRegex).ToList();

            xmlOpeningElements.Should().BeEmpty();
            xmlClosingElements.Should().BeEmpty();
        }

        [Test]
        public void MessageContentWithSymbolsReturnsEmptyList()
        {
            const string messageContent = "<hello@world.com>";

            IEnumerable<string> xmlOpeningElements = IdentifyXmlElementsService.IdentifyXmlElements(messageContent, RegularExpressions.XmlOpenElementRegex).ToList();
            IEnumerable<string> xmlClosingElements = IdentifyXmlElementsService.IdentifyXmlElements(messageContent, RegularExpressions.XmlCloseElementRegex).ToList();

            xmlOpeningElements.Should().BeEmpty();
            xmlClosingElements.Should().BeEmpty();
        }

        [Test]
        [TestCase("<test/>")]
        [TestCase("<test />")]
        public void MessageContentWithSelfClosingXmlElementReturnsEmptyList(string messageContent)
        {
            IEnumerable<string> xmlElements = IdentifyXmlElementsService.IdentifyXmlElements(messageContent, RegularExpressions.XmlOpenElementRegex).ToList();

            xmlElements.Should().BeEmpty();
        }

        [Test]
        [TestCase(
@"<expense><cost_centre></cost_centre>
    <total>1024.01</total><payment_method>personal card</payment_method>
</expense>", "expense")]
        [TestCase("<vendor>Viaduct Steakhouse</vendor>", "vendor")]
        public void CanExtractXmlContent(string messageContent, string xmlElement)
        {
            string extractXmlContent = IdentifyXmlElementsService.ExtractXmlContent(messageContent, RegularExpressions.XmlContentRegex, xmlElement);

            extractXmlContent.Should().Be(messageContent);
        }

        [Test]
        [TestCase(
@"<expense><cost_centre></cost_centre>
    <total>1024.01</total><payment_method>personal card</payment_method>
</expense>", "test")]
        [TestCase("<vendor>Viaduct Steakhouse</vendor>", "test")]
        public void UnableToExtractXmlContentReturnsEmptyString(string messageContent, string xmlElement)
        {
            string extractXmlContent = IdentifyXmlElementsService.ExtractXmlContent(messageContent, RegularExpressions.XmlContentRegex, xmlElement);

            extractXmlContent.Should().BeEmpty();
        }
    }
 }