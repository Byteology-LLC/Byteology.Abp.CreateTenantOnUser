using Byteology.Abp.CreateTenantOnUser.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Byteology.Abp.CreateTenantOnUser.Permissions;

public class CreateTenantOnUserPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CreateTenantOnUserPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CreateTenantOnUserPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CreateTenantOnUserResource>(name);
    }
}
