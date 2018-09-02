using FluentAssertions;
using NUnit.Framework;
using Xml.Content.Parser.Core.Domain;
using Xml.Content.Parser.Tests.Common;

namespace Xml.Content.Parser.Core.Tests.Services
{
    [TestFixture]
    [Category("UnitTests")]
    [Category("XmlExtraction")]
    public class XmlExtractionServiceTests : TestBase
    {
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

            Assert.DoesNotThrow(() =>
            {
                Expense expense = XmlExtractionService.Extract(messageContent);

                expense.CostCentre.Should().NotBeNullOrEmpty();
                expense.TotalInclGst.Should().BeGreaterThan(0m);
                expense.TotalExclGst.Should().BeGreaterThan(0m);
                expense.GstAmount.Should().BeGreaterThan(0m);
                expense.Vendor.Should().NotBeNullOrEmpty();
                expense.Description.Should().NotBeNullOrEmpty();
                expense.DateEvent.Should().NotBeNullOrEmpty();
            });
        }
    }
}