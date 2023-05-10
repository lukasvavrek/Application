using Application.Domain.Operations.Create;
using Application.Domain.Operations.Search;
using Application.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Domain;

public static class DependencyInjection
{
    public static void AddDomain(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddScoped<IApplicationService, ApplicationService>();

        services.AddScoped<CreateApplicationOperation>();
        services.AddScoped<SearchApplicationsOperation>();
    }
}