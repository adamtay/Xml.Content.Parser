using System;
using System.Collections.Generic;
using System.Linq;
using Xml.Content.Parser.Common;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Repository.Interfaces;

namespace Xml.Content.Parser.Core.Validators
{
    public class MandatoryXmlElementsValidator : IXmlElementValidator
    {
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;
        private readonly IValidationRepository _validationRepository;

        public MandatoryXmlElementsValidator(IIdentifyXmlElementsService identifyXmlElementsService, IValidationRepository validationRepository)
        {
            if (identifyXmlElementsService == null) throw new ArgumentNullException(nameof(identifyXmlElementsService));
            if (validationRepository == null) throw new ArgumentNullException(nameof(validationRepository));

            _identifyXmlElementsService = identifyXmlElementsService;
            _validationRepository = validationRepository;
        }

        public void Validate(string messageContent)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));

            IEnumerable<string> mandatoryXmlElements = _validationRepository.GetMandatoryXmlElements().ToList();

            bool isValid = mandatoryXmlElements.All(xmlElement => !string.IsNullOrWhiteSpace(
                _identifyXmlElementsService.ExtractXmlContent(messageContent, RegularExpressions.XmlContentRegex, xmlElement)));

            if (!isValid)
            {
                throw new XmlContentParserException($"The specified message content does not contain all mandatory XML elements. Mandatory elements: '{string.Join(",", mandatoryXmlElements)}'.");
            }
        }
    }
}