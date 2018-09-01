using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Xml.Content.Parser.Common;
using Xml.Content.Parser.Core.Domain;
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
        public void CanExtractXmlContent1()
        {
            const string messageContent =
@"<expense><cost_centre>DEV002</cost_centre>
    <total>1024.01</total><payment_method>personal card</payment_method>
</expense>";

            string extractXmlContent = IdentifyXmlElementsService.ExtractXmlContent(messageContent, RegularExpressions.XmlContentRegex, "expense");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(extractXmlContent);

            string serializeXmlNode = JsonConvert.SerializeXmlNode(xmlDocument);
            ExpenseDto deserializeObject = JsonConvert.DeserializeObject<ExpenseDto>(serializeXmlNode);

            extractXmlContent.Should().Be(messageContent);
        }

        [Test]
        public void CanExtractXmlContent2()
        {
            const string messageContent = @"<vendor>Viaduct Steakhouse</vendor>";

            string extractXmlContent = IdentifyXmlElementsService.ExtractXmlContent(messageContent, RegularExpressions.XmlContentRegex, "vendor");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(extractXmlContent);

            string serializeXmlNode = JsonConvert.SerializeXmlNode(xmlDocument);
            VendorDto deserializeObject = JsonConvert.DeserializeObject<VendorDto>(serializeXmlNode);

            extractXmlContent.Should().Be(messageContent);
        }
    }
 }