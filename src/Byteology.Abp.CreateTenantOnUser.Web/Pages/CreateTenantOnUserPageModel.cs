using Byteology.Abp.CreateTenantOnUser.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Byteology.Abp.CreateTenantOnUser.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CreateTenantOnUserPageModel : AbpPageModel
{
    protected CreateTenantOnUserPageModel()
    {
        LocalizationResourceType = typeof(CreateTenantOnUserResource);
    }
}
