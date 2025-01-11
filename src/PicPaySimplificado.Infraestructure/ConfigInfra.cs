using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PicPaySimplificado.Infraestructure.Data;

namespace PicPaySimplificado.Infraestructure
{
    public static class ConfigInfra
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigDbContext(configuration, services);
            return services;
        }

        public static void ConfigDbContext(IConfiguration configuration, IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(x => x.UseNpgsql(connectionString));
        }
    }
}
