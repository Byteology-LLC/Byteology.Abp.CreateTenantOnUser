using System.Threading.Tasks;

namespace Byteology.Abp.CreateTenantOnUser.Data;

public interface ICreateTenantOnUserDbSchemaMigrator
{
    Task MigrateAsync();
}
