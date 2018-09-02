using System;
using System.Collections.Generic;
using Xml.Content.Parser.Common;
using Xml.Content.Parser.Core.Domain;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Core.Mappers;

namespace Xml.Content.Parser.Core.Services
{
    public class XmlExtractionService
    {
        private readonly IXmlValidationFactory _xmlValidationFactory;
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;
        private readonly IXmlDeserializerService _xmlDeserializerService;

        public XmlExtractionService(IXmlValidationFactory xmlValidationFactory, IIdentifyXmlElementsService identifyXmlElementsService,
            IXmlDeserializerService xmlDeserializerService)
        {
            if (xmlValidationFactory == null) throw new ArgumentNullException(nameof(xmlValidationFactory));
            if (identifyXmlElementsService == null) throw new ArgumentNullException(nameof(identifyXmlElementsService));
            if (xmlDeserializerService == null) throw new ArgumentNullException(nameof(xmlDeserializerService));

            _xmlValidationFactory = xmlValidationFactory;
            _identifyXmlElementsService = identifyXmlElementsService;
            _xmlDeserializerService = xmlDeserializerService;
        }

        public Expense Extract(string messageContent)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));

            ValidateMessageContent(messageContent);

            ExpenseDto expenseDto = ExtractAndDeserializeXmlElement<ExpenseDto>(messageContent, "expense");
            VendorDto vendorDto = ExtractAndDeserializeXmlElement<VendorDto>(messageContent, "vendor");
            DescriptionDto descriptionDto = ExtractAndDeserializeXmlElement<DescriptionDto>(messageContent, "description");
            DateEventDto dateEventDto = ExtractAndDeserializeXmlElement<DateEventDto>(messageContent, "date");

            return ExpenseMapper.Map(expenseDto, vendorDto, descriptionDto, dateEventDto);
        }

        private void ValidateMessageContent(string messageContent)
        {
            IEnumerable<IXmlElementValidator> xmlElementValidators = _xmlValidationFactory.CreateValidators();

            foreach (IXmlElementValidator xmlElementValidator in xmlElementValidators)
            {
                xmlElementValidator.Validate(messageContent);
            }
        }

        private T ExtractAndDeserializeXmlElement<T>(string messageContent, string element)
        {
            string xmlContent = _identifyXmlElementsService.ExtractXmlContent(messageContent, RegularExpressions.XmlContentRegex, element);

            return _xmlDeserializerService.Deserialize<T>(xmlContent);
        }
    }
}