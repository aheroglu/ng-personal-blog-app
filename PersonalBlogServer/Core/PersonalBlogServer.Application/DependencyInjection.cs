using Microsoft.Extensions.DependencyInjection;

namespace PersonalBlogServer.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(configuartion =>
            {
                configuartion.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

        return services;
    }
}
