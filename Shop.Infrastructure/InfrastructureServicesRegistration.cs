using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Security;
using Shop.Infrastructure.Security;

namespace Shop.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static void ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
        }
    }
}
