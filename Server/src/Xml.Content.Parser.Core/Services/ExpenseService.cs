﻿using System;
using System.Collections.Generic;
using Xml.Content.Parser.Common;
using Xml.Content.Parser.Core.Constants;
using Xml.Content.Parser.Core.Domain;
using Xml.Content.Parser.Core.Domain.XmlContracts;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Core.Mappers;

namespace Xml.Content.Parser.Core.Services
{
    /// <summary>
    /// Responsible for all operations against the <see cref="Expense"/> <see cref="object"/>. 
    /// </summary>
    /// <seealso cref="Xml.Content.Parser.Core.Interfaces.IExpenseService" />
    public class ExpenseService : IExpenseService
    {
        private readonly IXmlValidationFactory _xmlValidationFactory;
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;
        private readonly IXmlDeserializerService _xmlDeserializerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseService"/> class.
        /// </summary>
        /// <param name="xmlValidationFactory">The XML validation factory.</param>
        /// <param name="identifyXmlElementsService">The identify XML elements service.</param>
        /// <param name="xmlDeserializerService">The XML deserializer service.</param>
        /// <exception cref="ArgumentNullException">
        /// xmlValidationFactory
        /// or
        /// identifyXmlElementsService
        /// or
        /// xmlDeserializerService
        /// </exception>
        public ExpenseService(IXmlValidationFactory xmlValidationFactory, IIdentifyXmlElementsService identifyXmlElementsService,
            IXmlDeserializerService xmlDeserializerService)
        {
            if (xmlValidationFactory == null) throw new ArgumentNullException(nameof(xmlValidationFactory));
            if (identifyXmlElementsService == null) throw new ArgumentNullException(nameof(identifyXmlElementsService));
            if (xmlDeserializerService == null) throw new ArgumentNullException(nameof(xmlDeserializerService));

            _xmlValidationFactory = xmlValidationFactory;
            _identifyXmlElementsService = identifyXmlElementsService;
            _xmlDeserializerService = xmlDeserializerService;
        }

        /// <summary>
        /// Extracts the specified message content.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace. - messageContent</exception>
        // TODO: This method only extracts a single Expense object. Nice to have would be to expand and extract multiple Expenses.
        public Expense Extract(string messageContent)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));

            ValidateMessageContent(messageContent);

            ExpenseDto expense = ExtractAndDeserializeExpenseXmlElement(messageContent);
            VendorDto vendor = ExtractAndDeserializeXmlElement<VendorDto>(messageContent, ExpenseConstants.Vendor);
            DescriptionDto description = ExtractAndDeserializeXmlElement<DescriptionDto>(messageContent, ExpenseConstants.Description);
            EventDateDto eventDate = ExtractAndDeserializeXmlElement<EventDateDto>(messageContent, ExpenseConstants.Date);

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
            ExpenseDto expenseDto = ExtractAndDeserializeXmlElement<ExpenseDto>(messageContent, ExpenseConstants.Expense);
            if (expenseDto != null)
            {
                return expenseDto;
            }

            CostCentreDto costCentre = ExtractAndDeserializeXmlElement<CostCentreDto>(messageContent, ExpenseConstants.CostCentre);
            TotalDto total = ExtractAndDeserializeXmlElement<TotalDto>(messageContent, ExpenseConstants.Total);
            PaymentMethodDto paymentMethod = ExtractAndDeserializeXmlElement<PaymentMethodDto>(messageContent, ExpenseConstants.PaymentMethod);

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