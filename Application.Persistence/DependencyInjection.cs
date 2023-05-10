using Application.Domain.Repositories;
using Application.Persistence.Database;
using Application.Persistence.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddScoped<IApplicationRepository, ApplicationRepository>();

        services.AddDbContext<ApplicationContext>();
    }
}