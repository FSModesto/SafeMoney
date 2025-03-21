using Application.Handlers;
using Application.Interfaces;
using Application.Validators.User;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using FluentValidation;
using Infra.Repository;
using Infra.Service.Services;

namespace SafeMoneyAPI.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddHandlers(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            services.AddScoped<IUserHandler, UserHandler>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            services.AddHttpContextAccessor();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ISendEmailService, SendEmailService>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
        }
    }
}
