using Volo.Abp.Modularity;

namespace Byteology.Abp.CreateTenantOnUser;

/* Inherit from this class for your domain layer tests. */
public abstract class CreateTenantOnUserDomainTestBase<TStartupModule> : CreateTenantOnUserTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
