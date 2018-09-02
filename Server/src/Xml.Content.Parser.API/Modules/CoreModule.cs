using System;
using Autofac;
using Xml.Content.Parser.Core.Factories;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Core.Services;

namespace Xml.Content.Parser.API.Modules
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            
            // Services
            builder.RegisterType<IdentifyXmlElementsService>().As<IIdentifyXmlElementsService>();
            builder.RegisterType<XmlDeserializerService>().As<IXmlDeserializerService>();
            builder.RegisterType<ExpenseService>().As<IExpenseService>();

            // Factories
            builder.RegisterType<XmlValidationFactory>().As<IXmlValidationFactory>();
        }
    }
}