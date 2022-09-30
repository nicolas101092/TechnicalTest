using Domain.Common.Settings;

namespace Infrastructure.Common.Configuration
{
    /// <summary>
    /// Class for inject the services in the api
    /// </summary>
    public static class ConfigureServiceExtension
    {
        /// <summary>
        /// Load the configuration of swagger in the method ConfigureService
        /// </summary>
        /// <param name="services">a object IServiceCollection to inject the dependences</param>
        /// <param name="configuration">a object IConfiguration with the swagger configuration</param>
        /// <param name="assemblyName">the name of assembly</param>
        /// <param name="baseDirectory">the baseDirectory of assembly</param>
        /// <returns>a object IServiceCollection with the result</returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration, string? assemblyName, string baseDirectory)
        {
            //get values of object SwaggerConfig
            SwaggerSettings swaggerConfig = new SwaggerSettings();
            configuration.GetSection("SwaggerConfig").Bind(swaggerConfig);

            services.AddSwaggerGen(c =>
            {
                string xmlFile = $"{assemblyName}.xml";
                string xmlPath = Path.Combine(baseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc(swaggerConfig.Version, new OpenApiInfo { Title = swaggerConfig.Title, Version = swaggerConfig.Version });

                c.CustomSchemaIds(x => x.FullName);
            });

            return services;
        }
    }
}
