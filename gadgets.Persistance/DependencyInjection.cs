using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using gadgets.Application.Interfaces;
namespace gadgets.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<gadgetsDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IgadgetsDbContext>(provider => provider.GetService<gadgetsDbContext>());
            return services;
        }
    }
}
