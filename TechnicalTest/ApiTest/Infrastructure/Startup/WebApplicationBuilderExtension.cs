using App.Utils.EntityFrameworkCore.Configure;
using Application.Services.ApiTest.Commands.InventoryCommands;
using Application.Services.ApiTest.Commands.ItemCommands;
using Application.Services.ApiTest.DtoModels.AutoMapper;
using Application.Services.ApiTest.Queries.InventoryQueries;
using Application.Services.ApiTest.Queries.ItemQueries;
using Domain.Common.Constants;
using FluentValidation;
using Infrastructure.Persistence.Contexts.ApiTest;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System;
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
            builder.Services.AddScoped<IInventoryQueries, InventoryQueries>();
            builder.Services.AddScoped<IItemQueries, ItemQueries>();
            builder.Services.AddScoped<IValidator<CreateInventoryCommand>, CreateInventoryValidator>();
            builder.Services.AddScoped<IValidator<CreateItemCommand>, CreateItemValidator>();
            builder.Services.AddSecurityConfiguration();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(typeof(ApiTestAutorMapper).GetTypeInfo().Assembly);
            builder.Services.AddSwagger(builder.Configuration, Assembly.GetExecutingAssembly().GetName().Name, AppContext.BaseDirectory);
            builder.Services.AddDbContext<InventoryContext>(o => o.UseInMemoryDatabase("TechnicalTestDb"));
            builder.Services.AddDbContext<ApiTestContext>(o => o.UseInMemoryDatabase("TechnicalTestDb"));
            builder.Services.AddBaseRepository();
            builder.Services.AddMediatR(x => x.WithEvaluator(y => y.Namespace != null && y.Namespace.StartsWith(ConstantsStartup.NAMESPACE_APP_SERVICES_TEST_API)),
                                                typeof(CreateInventoryCommandHandler).GetTypeInfo().Assembly);

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
