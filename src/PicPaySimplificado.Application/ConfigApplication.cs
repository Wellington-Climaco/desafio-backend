using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PicPaySimplificado.Application.Interface;
using PicPaySimplificado.Application.Request;
using PicPaySimplificado.Application.Services;
using PicPaySimplificado.Application.Validation.Wallet;

namespace PicPaySimplificado.Application
{
    public static class ConfigApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IWalletService, WalletService>();

            ConfigValidators(services);
            return services;
        }

        public static void ConfigValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateWalletRequest>,CreateWalletValidation>();
        }
    }
}
