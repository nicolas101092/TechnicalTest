using App.Utils.Middlewares.Core.Middlewares;

namespace ApiTest.Infrastructure.Startup
{
    /// <summary>
    /// Class for configuring the api execution pipeline
    /// </summary>
    public static class WebApplicationExtension
    {
        /// <summary>
        /// Method for configuring api services
        /// </summary>
        /// <param name="app">A WebApplication object for configuring the pipeline</param>
        public static void Configure(this WebApplication app)
        {
            app.UseCaptureLogsMiddleware();
            app.UseCaptureExceptionsMiddleware();
            app.UseHttpsRedirection();
            app.UseSwaggerIfDevelopment();
            app.MapControllers();
            app.Run();
        }
    }
}
