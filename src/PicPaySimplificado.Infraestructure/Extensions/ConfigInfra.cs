using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PicPaySimplificado.Core.Interface;
using PicPaySimplificado.Infraestructure.Data;
using PicPaySimplificado.Infraestructure.Repository;

namespace PicPaySimplificado.Infraestructure.Extensions
{
    public static class ConfigInfra
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            DependencyInjection(services);
            ConfigDbContext(configuration, services);
            return services;
        }

        public static void ConfigDbContext(IConfiguration configuration, IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(x => x.UseNpgsql(connectionString));
        }

        public static void DependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IWalletRepository,WalletRepository>();
        }
    }
}
