using Xml.Content.Parser.Core.Factories;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Core.Services;
using Xml.Content.Parser.Core.Validators;

namespace Xml.Content.Parser.Tests.Common
{
    public class TestBase
    {
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;
        private readonly IXmlElementValidator _containsXmlElementsValidator;
        private readonly IXmlElementValidator _noMissingXmlElementsValidator;
        private readonly IXmlValidationFactory _xmlValidationFactory;
        private readonly XmlExtractionService _xmlExtractionService;

        protected TestBase()
        {
            _identifyXmlElementsService = new IdentifyXmlElementsService();
            _containsXmlElementsValidator = new ContainsXmlElementsValidator(_identifyXmlElementsService);
            _noMissingXmlElementsValidator = new NoMissingXmlElementsValidator(_identifyXmlElementsService);
            _xmlValidationFactory = new XmlValidationFactory(_identifyXmlElementsService);
            _xmlExtractionService = new XmlExtractionService(_xmlValidationFactory);
        }

        // Services
        protected IIdentifyXmlElementsService IdentifyXmlElementsService => _identifyXmlElementsService;
        protected XmlExtractionService XmlExtractionService => _xmlExtractionService;

        // Validators
        protected IXmlElementValidator ContainsXmlElementsValidator => _containsXmlElementsValidator;
        protected IXmlElementValidator NoMissingXmlElementsValidator => _noMissingXmlElementsValidator;

        // Factories
        protected IXmlValidationFactory XmlValidationFactory => _xmlValidationFactory;
    }
}