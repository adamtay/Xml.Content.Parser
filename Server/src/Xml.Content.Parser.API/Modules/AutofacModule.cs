using System;
using Autofac;
using Xml.Content.Parser.Common.Interfaces;
using Xml.Content.Parser.Common.Logger;

namespace Xml.Content.Parser.API.Modules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.RegisterModule<CommonModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<CoreModule>();
        }
    }

    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.RegisterType<Logger>().As<ILogger>();
        }
    }
}