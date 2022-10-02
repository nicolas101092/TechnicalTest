using Microsoft.Extensions.Hosting;

namespace Infrastructure.Common.Configuration
{
    public static class ConfigureExtension
    {
        public static WebApplication UseSwaggerIfDevelopment(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}
