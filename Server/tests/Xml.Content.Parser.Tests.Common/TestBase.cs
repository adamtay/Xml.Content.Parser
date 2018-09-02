using NSubstitute;
using Xml.Content.Parser.Core.Factories;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Core.Services;
using Xml.Content.Parser.Core.Validators;
using Xml.Content.Parser.Repository.Interfaces;

namespace Xml.Content.Parser.Tests.Common
{
    public class TestBase
    {
        private readonly IValidationRepository _validationRepository;
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;
        private readonly IXmlElementValidator _containsXmlElementsValidator;
        private readonly IXmlElementValidator _noMissingXmlElementsValidator;
        private readonly IXmlElementValidator _validXmlElementsValidator;
        private readonly IXmlElementValidator _mandatoryXmlElementsValidator;
        private readonly IXmlValidationFactory _xmlValidationFactory;
        private readonly XmlExtractionService _xmlExtractionService;

        protected TestBase()
        {
            _validationRepository = Substitute.For<IValidationRepository>();
            _identifyXmlElementsService = new IdentifyXmlElementsService();
            _containsXmlElementsValidator = new ContainsXmlElementsValidator(_identifyXmlElementsService);
            _noMissingXmlElementsValidator = new NoMissingXmlElementsValidator(_identifyXmlElementsService);
            _validXmlElementsValidator = new ValidXmlElementsValidator(_identifyXmlElementsService);
            _mandatoryXmlElementsValidator = new MandatoryXmlElementsValidator(_identifyXmlElementsService, _validationRepository);
            _xmlValidationFactory = new XmlValidationFactory(_identifyXmlElementsService, _validationRepository);
            _xmlExtractionService = new XmlExtractionService(_xmlValidationFactory, _identifyXmlElementsService, new XmlDeserializerService());
        }

        // Repositories
        protected IValidationRepository ValidationRepository => _validationRepository;

        // Services
        protected IIdentifyXmlElementsService IdentifyXmlElementsService => _identifyXmlElementsService;
        protected XmlExtractionService XmlExtractionService => _xmlExtractionService;

        // Validators
        protected IXmlElementValidator ContainsXmlElementsValidator => _containsXmlElementsValidator;
        protected IXmlElementValidator NoMissingXmlElementsValidator => _noMissingXmlElementsValidator;
        protected IXmlElementValidator ValidXmlElementsValidator => _validXmlElementsValidator;
        protected IXmlElementValidator MandatoryXmlElementsValidator => _mandatoryXmlElementsValidator;

        // Factories
        protected IXmlValidationFactory XmlValidationFactory => _xmlValidationFactory;
    }
}