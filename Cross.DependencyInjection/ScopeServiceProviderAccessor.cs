namespace Cross.DependencyInjection;

public class ScopeServiceProviderAccessor : IScopeServiceProviderAccessor
{
    private static readonly AsyncLocal<ServiceProviderHolder> _serviceProviderCurrent = new();

    public IServiceProvider ServiceProvider
    {
        get => _serviceProviderCurrent.Value?.ServiceProvider;
        set
        {
            var holder = _serviceProviderCurrent.Value;

            if (holder != null)
            {
                holder.ServiceProvider = null;
            }

            if (value != null)
            {
                _serviceProviderCurrent.Value = new ServiceProviderHolder { ServiceProvider = value };
            }
        }
    }

    private sealed class ServiceProviderHolder
    {
        public IServiceProvider ServiceProvider;
    }
}
