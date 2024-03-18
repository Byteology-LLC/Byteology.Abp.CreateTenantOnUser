using Volo.Abp.Modularity;

namespace Byteology.Abp.CreateTenantOnUser;

[DependsOn(
    typeof(CreateTenantOnUserDomainModule),
    typeof(CreateTenantOnUserTestBaseModule)
)]
public class CreateTenantOnUserDomainTestModule : AbpModule
{

}
