using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Byteology.Abp.CreateTenantOnUser.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class CreateTenantOnUserDbContextFactory : IDesignTimeDbContextFactory<CreateTenantOnUserDbContext>
{
    public CreateTenantOnUserDbContext CreateDbContext(string[] args)
    {
        CreateTenantOnUserEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CreateTenantOnUserDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new CreateTenantOnUserDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Byteology.Abp.CreateTenantOnUser.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
