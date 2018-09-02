using System;
using Autofac;

namespace Xml.Content.Parser.API.Modules
{
    /// <summary>
    /// Represents all <see cref="Module"/> bindings used by the API.
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class AutofacModule : Module
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

            builder.RegisterModule<CommonModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<CoreModule>();
        }
    }
}