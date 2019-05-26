using Microsoft.Extensions.DependencyInjection;
using ZxVentures.BackendChallenge.Application.PDVS;
using ZxVentures.BackendChallenge.Infrastructure.Data;
using ZxVentures.BackendChallenge.Infrastructure.Repository;

namespace ZXVentures.BackendChallenge.Api
{
    public static class DependencyInjectionConfigurator
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPDVRepository, PDVRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<PDVService, PDVService>();
        }

        public static void AddDatabaseContext(this IServiceCollection services)
        {
            services.AddTransient<DatabaseContext, DatabaseContext>();
        }
    }
}
