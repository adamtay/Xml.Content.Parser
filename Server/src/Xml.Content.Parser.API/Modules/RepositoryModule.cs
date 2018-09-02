using System;
using Autofac;
using Xml.Content.Parser.Repository;
using Xml.Content.Parser.Repository.Interfaces;

namespace Xml.Content.Parser.API.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.RegisterType<ValidationRepository>().As<IValidationRepository>();
        }
    }
}