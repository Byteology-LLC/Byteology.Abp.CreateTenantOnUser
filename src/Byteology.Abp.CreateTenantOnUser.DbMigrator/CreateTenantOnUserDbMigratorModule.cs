using Byteology.Abp.CreateTenantOnUser.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Byteology.Abp.CreateTenantOnUser.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CreateTenantOnUserEntityFrameworkCoreModule),
    typeof(CreateTenantOnUserApplicationContractsModule)
    )]
public class CreateTenantOnUserDbMigratorModule : AbpModule
{
}
