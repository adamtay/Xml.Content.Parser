using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Core.Domain;
using Xml.Content.Parser.Tests.Common;

namespace Xml.Content.Parser.Core.Tests.Services
{
    [TestFixture]
    [Category("UnitTests")]
    [Category("XmlExtraction")]
    public class XmlExtractionServiceTests : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            ValidationRepository.GetMandatoryXmlElements().Returns(new List<string>
            {
                "<total>"
            });
        }

        [Test]
        public void CanExtractProvidedTestSample()
        {
            const string messageContent =
@"Hi Yvaine,

Please create an expense claim for the below. Relevant details are marked up as
requested...

<expense><cost_centre>DEV002</cost_centre>
    <total>1024.01</total><payment_method>personal card</payment_method>
</expense>

From: Ivan Castle
Sent: Friday, 16 February 2018 10:32 AM
To: Antoine Lloyd <Antoine.Lloyd@example.com>
Subject: test

Hi Antoine,

Please create a reservation at the <vendor>Viaduct Steakhouse</vendor> our
<description>development team’s project end celebration dinner</description> on
<date>Tuesday 27 April 2017</date>. We expect to arrive around
7.15pm. Approximately 12 people but I’ll confirm exact numbers closer to the day.

Regards,
Ivan";

            Expense expense = XmlExtractionService.Extract(messageContent);

            expense.CostCentre.Should().Be("DEV002");
            expense.TotalInclGst.Should().Be(1024.01m);
            expense.TotalExclGst.Should().Be(890.44m);
            expense.GstAmount.Should().Be(133.57m);
            expense.Vendor.Should().Be("Viaduct Steakhouse");
            expense.Description.Should().Be("development team’s project end celebration dinner");
            expense.EventDate.Should().Be("Tuesday 27 April 2017");
        }

        [Test]
        public void MessageContentWithoutCostCentreDefaultsToUnknown()
        {
            const string messageContent =
@"<expense>
    <total>1024.01</total><payment_method>personal card</payment_method>
</expense>";

            Expense expense = XmlExtractionService.Extract(messageContent);

            expense.CostCentre.Should().Be("UNKNOWN");
            expense.TotalInclGst.Should().Be(1024.01m);
            expense.TotalExclGst.Should().Be(890.44m);
            expense.GstAmount.Should().Be(133.57m);
            expense.Vendor.Should().BeEmpty();
            expense.Description.Should().BeEmpty();
            expense.EventDate.Should().BeEmpty();
        }

        [Test]
        public void CanExtractMessageContentWithNoParentBlocks()
        {
            const string messageContent =
@"<cost_centre>DEV002</cost_centre>
<total>1024.01</total>
<payment_method>personal card</payment_method>
<vendor>Viaduct Steakhouse</vendor>
<description>development team’s project end celebration dinner</description>
<date>Tuesday 27 April 2017</date>";

            Expense expense = XmlExtractionService.Extract(messageContent);

            expense.CostCentre.Should().Be("DEV002");
            expense.TotalInclGst.Should().Be(1024.01m);
            expense.TotalExclGst.Should().Be(890.44m);
            expense.GstAmount.Should().Be(133.57m);
            expense.Vendor.Should().Be("Viaduct Steakhouse");
            expense.Description.Should().Be("development team’s project end celebration dinner");
            expense.EventDate.Should().Be("Tuesday 27 April 2017");
        }

        [Test]
        public void MessageContentWithoutTotalThrowsException()
        {
            const string messageContent =
@"<expense><cost_centre>DEV002</cost_centre>
    <payment_method>personal card</payment_method>
</expense>";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                XmlExtractionService.Extract(messageContent);
            });

            exception.Message.Should()
                .Be("The specified message content does not contain all mandatory XML elements. Mandatory elements: '<total>'.");
        }

        [Test]
        public void MessageContentWithNonUseCaseXmlThrowsException()
        {
            const string messageContent =
@"<email>
    <from>Ivan Castle</from>
    <sent>Friday, 16 February 2018 10:32 AM</sent>
    <to>Antoine Lloyd <Antoine.Lloyd@example.com></to>
    <subject>test</subject>
</email>";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                XmlExtractionService.Extract(messageContent);
            });

            exception.Message.Should()
                .Be("The specified message content does not contain all mandatory XML elements. Mandatory elements: '<total>'.");
        }

        [Test]
        public void MessageContentWithNoXmlElementsThrowsException()
        {
            const string messageContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                XmlExtractionService.Extract(messageContent);
            });

            exception.Message.Should()
                .Be("The specified message content does not contain any valid XML elements.");
        }

        [Test]
        public void MessageContentWithMissingClosingTagThrowsException()
        {
            const string messageContent =
@"<expense><cost_centre>DEV002</cost_centre>
    <total>1024.01</total><payment_method>personal card</payment_method>";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                XmlExtractionService.Extract(messageContent);
            });

            exception.Message.Should()
                .Be("The specified message content contains XML elements without it's corresponding pair.");
        }
    }
}