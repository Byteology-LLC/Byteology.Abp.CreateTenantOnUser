using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Byteology.Abp.CreateTenantOnUser.Web;

[Dependency(ReplaceServices = true)]
public class CreateTenantOnUserBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CreateTenantOnUser";
}
