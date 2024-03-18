using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Byteology.Abp.CreateTenantOnUser.Data;
using Volo.Abp.DependencyInjection;

namespace Byteology.Abp.CreateTenantOnUser.EntityFrameworkCore;

public class EntityFrameworkCoreCreateTenantOnUserDbSchemaMigrator
    : ICreateTenantOnUserDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCreateTenantOnUserDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the CreateTenantOnUserDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CreateTenantOnUserDbContext>()
            .Database
            .MigrateAsync();
    }
}
