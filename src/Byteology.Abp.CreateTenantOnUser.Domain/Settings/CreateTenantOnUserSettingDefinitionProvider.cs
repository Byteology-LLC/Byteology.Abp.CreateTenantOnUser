using Volo.Abp.Settings;

namespace Byteology.Abp.CreateTenantOnUser.Settings;

public class CreateTenantOnUserSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CreateTenantOnUserSettings.MySetting1));
    }
}
