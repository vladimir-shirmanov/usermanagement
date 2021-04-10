using DomainBusinessLogic.Interfaces;
using DomainBusinessLogic.Services;
using DomainBusinessLogic.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.WebApi.Utilities
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserRegisterResolver, UserRegisterResolver>();
            services.AddScoped<IUserRegisterStrategy, MrGreenRegisterStrategy>();
            services.AddScoped<IUserRegisterStrategy, RedBetRegisterStrategy>();

            return services;
        }
    }
}