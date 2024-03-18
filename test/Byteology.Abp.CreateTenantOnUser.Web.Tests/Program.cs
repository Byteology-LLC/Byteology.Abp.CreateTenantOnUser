using Microsoft.AspNetCore.Builder;
using Byteology.Abp.CreateTenantOnUser;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<CreateTenantOnUserWebTestModule>();

public partial class Program
{
}
