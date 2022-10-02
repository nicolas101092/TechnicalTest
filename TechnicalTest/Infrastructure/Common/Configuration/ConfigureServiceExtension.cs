using Domain.Common.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });

                c.SwaggerDoc(swaggerConfig.Version, new OpenApiInfo { Title = swaggerConfig.Title, Version = swaggerConfig.Version });

                c.CustomSchemaIds(x => x.FullName);
            });

            return services;
        }


        /// <summary>
        /// Defines basic authentication
        /// </summary>
        /// <param name="services">Interface of type IServiceCollection</param>
        /// <returns>Interface of type IServiceCollection</returns>
        public static IServiceCollection AddSecurityConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = "https://demo.duendesoftware.com/";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters.ValidAudience = "api";
            });

            return services;
        }
    }
}
