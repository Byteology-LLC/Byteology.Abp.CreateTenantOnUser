using System;
using System.Collections.Generic;
using System.Text;
using Byteology.Abp.CreateTenantOnUser.Localization;
using Volo.Abp.Application.Services;

namespace Byteology.Abp.CreateTenantOnUser;

/* Inherit your application services from this class.
 */
public abstract class CreateTenantOnUserAppService : ApplicationService
{
    protected CreateTenantOnUserAppService()
    {
        LocalizationResource = typeof(CreateTenantOnUserResource);
    }
}
