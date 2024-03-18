using Byteology.Abp.CreateTenantOnUser.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Byteology.Abp.CreateTenantOnUser.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CreateTenantOnUserController : AbpControllerBase
{
    protected CreateTenantOnUserController()
    {
        LocalizationResource = typeof(CreateTenantOnUserResource);
    }
}
