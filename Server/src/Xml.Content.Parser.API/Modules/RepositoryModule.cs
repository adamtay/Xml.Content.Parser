using System;
using Autofac;
using Xml.Content.Parser.Repository;
using Xml.Content.Parser.Repository.Interfaces;

namespace Xml.Content.Parser.API.Modules
{
    /// <summary>
    /// Represents all <see cref="RepositoryModule"/> bindings used by the API.
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class RepositoryModule : Module
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

            builder.RegisterType<ValidationRepository>().As<IValidationRepository>();
        }
    }
}