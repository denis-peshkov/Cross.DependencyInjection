namespace Cross.DependencyInjection;

public class ScopeServiceProviderAccessorContext : IDisposable
{
    private readonly IScopeServiceProviderAccessor _scopeServiceProviderAccessor;

    public ScopeServiceProviderAccessorContext(IServiceProvider serviceProvider)
    {
        _scopeServiceProviderAccessor = serviceProvider.GetService<IScopeServiceProviderAccessor>();

        if (_scopeServiceProviderAccessor != null)
        {
            _scopeServiceProviderAccessor.ServiceProvider = serviceProvider;
        }
    }

    public void Dispose()
    {
        if (_scopeServiceProviderAccessor != null)
        {
            _scopeServiceProviderAccessor.ServiceProvider = null;
        }
    }
}
