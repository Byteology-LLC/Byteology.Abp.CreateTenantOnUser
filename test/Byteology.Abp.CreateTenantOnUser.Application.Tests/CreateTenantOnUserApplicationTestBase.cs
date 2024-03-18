using Volo.Abp.Modularity;

namespace Byteology.Abp.CreateTenantOnUser;

public abstract class CreateTenantOnUserApplicationTestBase<TStartupModule> : CreateTenantOnUserTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
