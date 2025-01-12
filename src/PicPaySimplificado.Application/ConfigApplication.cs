using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PicPaySimplificado.Application.Interface;
using PicPaySimplificado.Application.Request;
using PicPaySimplificado.Application.Services;
using PicPaySimplificado.Application.Validation.Transference;
using PicPaySimplificado.Application.Validation.Wallet;
using Uri = System.Uri;

namespace PicPaySimplificado.Application
{
    public static class ConfigApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
        {
            ConfigHttpClient(services,configuration);
            ConfigValidators(services);
            ConfigServices(services);
            return services;
        }

        public static void ConfigValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateWalletRequest>,CreateWalletValidation>();
            services.AddScoped<IValidator<TransferenceRequest>, TransferenceRequestValidation>();
        }

        public static void ConfigHttpClient(IServiceCollection services, IConfiguration configuration)
        {
            var urlAuthorizator = configuration.GetSection("AuthorizationService").Value ??
                                  throw new ArgumentNullException("AppSettings:AuthorizationService is null");
            
            services.AddHttpClient("Authorization", httpClient =>
            {
                httpClient.BaseAddress = new Uri(urlAuthorizator);
            });
        }

        public static void ConfigServices(IServiceCollection services)
        {
            services.AddScoped<ITransferenceService, TransferenceService>();
            services.AddScoped<IWalletService, WalletService>();
        }
    }
}
