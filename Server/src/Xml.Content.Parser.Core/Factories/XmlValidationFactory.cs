using System;
using System.Collections.Generic;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Core.Validators;
using Xml.Content.Parser.Repository.Interfaces;

namespace Xml.Content.Parser.Core.Factories
{
    /// <summary>
    /// Responsible for initializing all XML validators.
    /// </summary>
    /// <seealso cref="Xml.Content.Parser.Core.Interfaces.IXmlValidationFactory" />
    public class XmlValidationFactory : IXmlValidationFactory
    {
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;
        private readonly IValidationRepository _validationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlValidationFactory"/> class.
        /// </summary>
        /// <param name="identifyXmlElementsService">The identify XML elements service.</param>
        /// <param name="validationRepository">The validation repository.</param>
        /// <exception cref="ArgumentNullException">
        /// identifyXmlElementsService
        /// or
        /// validationRepository
        /// </exception>
        public XmlValidationFactory(IIdentifyXmlElementsService identifyXmlElementsService, IValidationRepository validationRepository)
        {
            if (identifyXmlElementsService == null) throw new ArgumentNullException(nameof(identifyXmlElementsService));
            if (validationRepository == null) throw new ArgumentNullException(nameof(validationRepository));

            _identifyXmlElementsService = identifyXmlElementsService;
            _validationRepository = validationRepository;
        }

        /// <summary>
        /// Creates the XML validators.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IXmlElementValidator> CreateValidators()
        {
            return new List<IXmlElementValidator>
            {
                new ContainsXmlElementsValidator(_identifyXmlElementsService),
                new NoMissingXmlElementsValidator(_identifyXmlElementsService),
                new ValidXmlElementsValidator(_identifyXmlElementsService),
                new MandatoryXmlElementsValidator(_identifyXmlElementsService, _validationRepository)
            };
        }
    }
}