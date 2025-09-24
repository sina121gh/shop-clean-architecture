using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Contracts.Infrastructure;
using Shop.Application.Security;
using Shop.Infrastructure.Security;
using Shop.Infrastructure.Services;
using StackExchange.Redis;

namespace Shop.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static void ConfigureInfrastructureServices(this IServiceCollection services,
            string redisConnection)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ICacheService, RedisService>();

            services.AddScoped<IDatabase>(cfg =>
            {
                IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(redisConnection);
                return multiplexer.GetDatabase();
            });
        }
    }
}
