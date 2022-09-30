using App.Utils.EntityFrameworkCore.Core.BaseRepository;

namespace App.Utils.EntityFrameworkCore.Configure
{
    public static class Configure
    {
        /// <summary>
        /// Inject the BaseRepository in the IoC of net core
        /// </summary>
        /// <param name="services">Collection of services of the app.</param>
        /// <returns><see cref="IServiceCollection" />to make chained calls.</returns>
        public static IServiceCollection AddBaseRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            return services;
        }
    }
}
