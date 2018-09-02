using System;
using System.Collections.Generic;
using System.Linq;
using Xml.Content.Parser.Common;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Repository.Interfaces;

namespace Xml.Content.Parser.Core.Validators
{
    /// <summary>
    /// Responsible for validating the specified message content.
    /// </summary>
    /// <seealso cref="Xml.Content.Parser.Core.Interfaces.IXmlElementValidator" />
    public class MandatoryXmlElementsValidator : IXmlElementValidator
    {
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;
        private readonly IValidationRepository _validationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MandatoryXmlElementsValidator"/> class.
        /// </summary>
        /// <param name="identifyXmlElementsService">The identify XML elements service.</param>
        /// <param name="validationRepository">The validation repository.</param>
        /// <exception cref="ArgumentNullException">
        /// identifyXmlElementsService
        /// or
        /// validationRepository
        /// </exception>
        public MandatoryXmlElementsValidator(IIdentifyXmlElementsService identifyXmlElementsService, IValidationRepository validationRepository)
        {
            if (identifyXmlElementsService == null) throw new ArgumentNullException(nameof(identifyXmlElementsService));
            if (validationRepository == null) throw new ArgumentNullException(nameof(validationRepository));

            _identifyXmlElementsService = identifyXmlElementsService;
            _validationRepository = validationRepository;
        }

        /// <summary>
        /// Validates the specified message content.
        /// Ensures that the <see cref="!:messageContent"/> contains all manadtory XML elements.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace. - messageContent</exception>
        /// <exception cref="XmlContentParserException"></exception>
        public void Validate(string messageContent)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));

            IEnumerable<string> mandatoryXmlElements = _validationRepository.GetMandatoryXmlElements().ToList();

            bool isValid = mandatoryXmlElements.All(xmlElement =>
            {
                string xmlContent = _identifyXmlElementsService.ExtractXmlContent(messageContent, RegularExpressions.XmlContentRegex, xmlElement);
                return !string.IsNullOrWhiteSpace(xmlContent) && !xmlContent.Equals($"{xmlElement}{xmlElement.Insert(1, "/")}");
            });

            if (!isValid)
            {
                throw new XmlContentParserException($"The specified message content does not contain all mandatory XML elements. Mandatory elements: '{string.Join(",", mandatoryXmlElements)}'.");
            }
        }
    }
}