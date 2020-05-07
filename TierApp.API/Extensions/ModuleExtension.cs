using TierApp.Data.Repository.EF;
using AutoMapper;
using TierApp.Data.Abstract;
using Microsoft.Extensions.DependencyInjection;
using TierApp.Business.Abstract;
using TierApp.Business.Services;

namespace TierApp.API.Extensions
{
    public static class ModuleExtension
    {
        public static void AddScopedServices(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAuthRepository, EfAuthRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();
        }
    }
}
