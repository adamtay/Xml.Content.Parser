using System;
using System.Collections.Generic;
using Xml.Content.Parser.Common;
using Xml.Content.Parser.Core.Domain;
using Xml.Content.Parser.Core.Domain.XmlContracts;
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

            ExpenseDto expense = ExtractAndDeserializeExpenseXmlElement(messageContent);
            VendorDto vendor = ExtractAndDeserializeXmlElement<VendorDto>(messageContent, "vendor");
            DescriptionDto description = ExtractAndDeserializeXmlElement<DescriptionDto>(messageContent, "description");
            EventDateDto eventDate = ExtractAndDeserializeXmlElement<EventDateDto>(messageContent, "date");

            return ExpenseMapper.Map(expense, vendor, description, eventDate);
        }

        private void ValidateMessageContent(string messageContent)
        {
            IEnumerable<IXmlElementValidator> xmlElementValidators = _xmlValidationFactory.CreateValidators();

            foreach (IXmlElementValidator xmlElementValidator in xmlElementValidators)
            {
                xmlElementValidator.Validate(messageContent);
            }
        }

        private ExpenseDto ExtractAndDeserializeExpenseXmlElement(string messageContent)
        {
            ExpenseDto expenseDto = ExtractAndDeserializeXmlElement<ExpenseDto>(messageContent, "expense");
            if (expenseDto != null)
            {
                return expenseDto;
            }

            CostCentreDto costCentre = ExtractAndDeserializeXmlElement<CostCentreDto>(messageContent, "cost_centre");
            TotalDto total = ExtractAndDeserializeXmlElement<TotalDto>(messageContent, "total");
            PaymentMethodDto paymentMethod = ExtractAndDeserializeXmlElement<PaymentMethodDto>(messageContent, "payment_method");

            return new ExpenseDto
            {
                Expense = new ExpenseDataDto
                {
                    CostCentre = costCentre?.CostCentre,
                    Total = total.Total,
                    PaymentMethod = paymentMethod?.PaymentMethod
                }
            };
        }

        private T ExtractAndDeserializeXmlElement<T>(string messageContent, string element)
        {
            string xmlContent = _identifyXmlElementsService.ExtractXmlContent(messageContent, RegularExpressions.XmlContentRegex, element);

            return !string.IsNullOrWhiteSpace(xmlContent) ? _xmlDeserializerService.Deserialize<T>(xmlContent) : default(T);
        }
    }
}