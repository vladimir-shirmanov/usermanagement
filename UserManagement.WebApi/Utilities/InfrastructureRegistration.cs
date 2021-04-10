using Ardalis.Specification;
using DatabaseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.WebApi.Utilities
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddDatabaseAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UserRegistrationContext>(c =>
                c.UseSqlServer(connectionString));

            services.AddScoped<DbContext, UserRegistrationContext>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(EfRepository<>));
            return services;
        }
    }
}