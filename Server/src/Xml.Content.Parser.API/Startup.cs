using System;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Xml.Content.Parser.API.Middleware;
using Xml.Content.Parser.API.Modules;

namespace Xml.Content.Parser.API
{
    /// <summary>
    /// Represents the API configurations.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <exception cref="ArgumentNullException">configuration</exception>
        public Startup(IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Responsible for registering all services. This method gets called by the runtime.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <exception cref="ArgumentNullException">services</exception>
        public void ConfigureServices(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info { Title = "Xml.Content.Parser.API", Version = "v1" });
#if RELEASE
                config.IncludeXmlComments($@"{AppContext.BaseDirectory}\{System.Reflection.Assembly.GetEntryAssembly().GetName().Name}.xml");
#endif
            });
        }

        /// <summary>
        /// Responsible for registering all Autofac modules. This method gets called by the runtime.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <exception cref="ArgumentNullException">builder</exception>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.RegisterModule<AutofacModule>();
        }

        /// <summary>
        /// Responsible for configuring the HTTP request pipeline. This method gets called by the runtime.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <exception cref="ArgumentNullException">
        /// app
        /// or
        /// env
        /// </exception>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            if (env == null) throw new ArgumentNullException(nameof(env));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Xml.Content.Parser.API v1");
            });
            app.UseMiddleware<UnhandledExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
