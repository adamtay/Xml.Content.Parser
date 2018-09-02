using FluentAssertions;
using NUnit.Framework;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Tests.Common;

namespace Xml.Content.Parser.Core.Tests.Services
{
    [TestFixture]
    [Category("UnitTests")]
    [Category("XmlExtraction")]
    public class XmlDeserializerServiceTests : TestBase
    {
        [Test]
        public void CanDeserializeXmlElement()
        {
            const string messageContent = "<child>hello</child>";

            XmlDeserializationChildElementTestObject xmlDeserializationChildElementTestObject = XmlDeserializerService.Deserialize<XmlDeserializationChildElementTestObject>(messageContent);

            xmlDeserializationChildElementTestObject.Child.Should().Be("hello");
        }

        [Test]
        public void CanDeserializeXmlElements()
        {
            const string messageContent = "<parent><child>hello</child></parent>";

            XmlDeserializationParentNodeTestObject xmlDeserializationParentNodeTestObject = XmlDeserializerService.Deserialize<XmlDeserializationParentNodeTestObject>(messageContent);

            xmlDeserializationParentNodeTestObject.Parent.Child.Should().Be("hello");
        }

        [Test]
        public void MessageContentWithValidSchemaReturnsNullProperty()
        {
            const string messageContent = "<test>hello</test>";

            XmlDeserializationChildElementTestObject xmlDeserializationChildElementTestObject = XmlDeserializerService.Deserialize<XmlDeserializationChildElementTestObject>(messageContent);

            xmlDeserializationChildElementTestObject.Child.Should().BeNull();
        }

        [Test]
        public void MessageContentWithInvalidSchemaThrowsException()
        {
            const string messageContent = "<test1>hello</test2>";

            XmlContentParserException exception = Assert.Throws<XmlContentParserException>(() =>
            {
                XmlDeserializerService.Deserialize<XmlDeserializationParentNodeTestObject>(messageContent);
            });

            exception.Message.Should()
                .Be($"The specified message content could not be deserialized into type: '{nameof(XmlDeserializationParentNodeTestObject)}'.");
        }

        private class XmlDeserializationParentNodeTestObject
        {
            public XmlDeserializationChildElementTestObject Parent { get; set; }
        }

        private class XmlDeserializationChildElementTestObject
        {
            public string Child { get; set; }
        }
    }
}