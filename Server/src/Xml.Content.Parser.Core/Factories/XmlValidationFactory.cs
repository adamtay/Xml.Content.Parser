using System;
using System.Collections.Generic;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Core.Validators;

namespace Xml.Content.Parser.Core.Factories
{
    public interface IXmlValidationFactory
    {
        IEnumerable<IXmlElementValidator> CreateValidators();
    }

    public class XmlValidationFactory : IXmlValidationFactory
    {
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;

        public XmlValidationFactory(IIdentifyXmlElementsService identifyXmlElementsService)
        {
            if (identifyXmlElementsService == null) throw new ArgumentNullException(nameof(identifyXmlElementsService));

            _identifyXmlElementsService = identifyXmlElementsService;
        }

        public IEnumerable<IXmlElementValidator> CreateValidators()
        {
            return new List<IXmlElementValidator>
            {
                new ContainsXmlElementsValidator(_identifyXmlElementsService),
                new NoMissingXmlElementsValidator(_identifyXmlElementsService)
            };
        }
    }
}