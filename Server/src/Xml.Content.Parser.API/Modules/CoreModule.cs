﻿using System;
using Autofac;
using Xml.Content.Parser.Core.Factories;
using Xml.Content.Parser.Core.Interfaces;
using Xml.Content.Parser.Core.Services;

namespace Xml.Content.Parser.API.Modules
{
    /// <summary>
    /// Represents all <see cref="CoreModule"/> bindings used by the API.
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class CoreModule : Module
    {
        /// <summary>
        /// Registers the specified modules.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <exception cref="ArgumentNullException">builder</exception>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
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