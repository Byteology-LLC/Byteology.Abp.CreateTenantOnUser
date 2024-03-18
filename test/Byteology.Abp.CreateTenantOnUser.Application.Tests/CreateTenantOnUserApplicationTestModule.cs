using Volo.Abp.Modularity;

namespace Byteology.Abp.CreateTenantOnUser;

[DependsOn(
    typeof(CreateTenantOnUserApplicationModule),
    typeof(CreateTenantOnUserDomainTestModule)
)]
public class CreateTenantOnUserApplicationTestModule : AbpModule
{

}
