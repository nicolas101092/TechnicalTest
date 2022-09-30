using System.Reflection;

namespace ApiTest.Infrastructure.Startup
{
    /// <summary>
    /// Class to configure the application
    /// </summary>
    public static class WebApplicationBuilderExtension
    {
        /// <summary>
        /// method for configure the services of api-rest
        /// </summary>
        /// <param name="builder">a object WebApplicationBuilder with the configuration</param>
        /// <returns>a object WebApplicationBuilder with the result</returns>
        public static WebApplicationBuilder ConfigureService(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger(builder.Configuration, Assembly.GetExecutingAssembly().GetName().Name, AppContext.BaseDirectory);

            return builder;
        }

        /// <summary>
        /// method for use the services of api-rest
        /// </summary>
        /// <param name="builder">a object WebApplicationBuilder with the configuration</param>
        public static void Configure(this WebApplicationBuilder builder)
        {
            builder.Build().Configure();
        }
    }
}
