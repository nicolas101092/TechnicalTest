using ApiTest.Infrastructure.Startup;

[assembly: ApiController]
[assembly: ApiConventionType(typeof(DefaultApiConventions))]
WebApplication.CreateBuilder(args)
              .ConfigureService()
              .Configure();
