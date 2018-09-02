using System;
using System.Collections.Generic;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Core.Validators;
using Xml.Content.Parser.Repository.Interfaces;

namespace Xml.Content.Parser.Core.Factories
{
    public class XmlValidationFactory : IXmlValidationFactory
    {
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;
        private readonly IValidationRepository _validationRepository;

        public XmlValidationFactory(IIdentifyXmlElementsService identifyXmlElementsService, IValidationRepository validationRepository)
        {
            if (identifyXmlElementsService == null) throw new ArgumentNullException(nameof(identifyXmlElementsService));
            if (validationRepository == null) throw new ArgumentNullException(nameof(validationRepository));

            _identifyXmlElementsService = identifyXmlElementsService;
            _validationRepository = validationRepository;
        }

        public IEnumerable<IXmlElementValidator> CreateValidators()
        {
            return new List<IXmlElementValidator>
            {
                new ContainsXmlElementsValidator(_identifyXmlElementsService),
                new NoMissingXmlElementsValidator(_identifyXmlElementsService),
                new MandatoryXmlElementsValidator(_identifyXmlElementsService, _validationRepository)
            };
        }
    }
}