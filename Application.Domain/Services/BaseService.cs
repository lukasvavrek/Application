using Microsoft.Extensions.DependencyInjection;

namespace Application.Domain.Services;

internal abstract class BaseService
{
    private readonly IServiceProvider _serviceProvider;

    protected BaseService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected TService Get<TService>()
    {
        return _serviceProvider.GetRequiredService<TService>();
    }
}