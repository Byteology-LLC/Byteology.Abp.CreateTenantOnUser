using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Byteology.Abp.CreateTenantOnUser.Data;

/* This is used if database provider does't define
 * ICreateTenantOnUserDbSchemaMigrator implementation.
 */
public class NullCreateTenantOnUserDbSchemaMigrator : ICreateTenantOnUserDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
