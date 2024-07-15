using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Persistence.Contexts;
using PersonalBlogServer.Persistence.Repositories;

namespace PersonalBlogServer.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services
            .AddScoped<IJwtProvider, JwtProvider>();

        services
            .AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

        return services;
    }
}
