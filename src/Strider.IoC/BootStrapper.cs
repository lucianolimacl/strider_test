using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Strider.Application.AppServices;
using Strider.Application.AutoMapperConfig;
using Strider.Application.Interfaces;
using Strider.Domain.Interfaces.Repositories;
using Strider.Domain.Interfaces.Services;
using Strider.Domain.Services;
using Strider.Infra;
using Strider.Infra.Repositories;

namespace Strider.IoC
{
    public static class BootStrapper
    {
        public static void Register(IServiceCollection services, IConfiguration configuration, string? assemblyName)
        {
            var conn = configuration.GetConnectionString("conn");

            services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new AutoMapperProfile());
            });
            services.AddTransient<IPostAppService, PostAppService>();
            services.AddTransient<IUserAppService, UserAppService>();

            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserFollowRepository, UserFollowRepository>();

            services.AddSqlServer<StriderDbContext>(conn, opt =>
            {
                opt.MigrationsAssembly(assemblyName);
            });
        }
    }
}