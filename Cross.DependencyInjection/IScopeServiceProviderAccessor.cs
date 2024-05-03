namespace Cross.DependencyInjection;

public interface IScopeServiceProviderAccessor
{
    IServiceProvider ServiceProvider { get; set; }
}
