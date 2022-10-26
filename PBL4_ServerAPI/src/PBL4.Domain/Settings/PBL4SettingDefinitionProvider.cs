using Volo.Abp.Settings;

namespace PBL4.Settings
{
    public class PBL4SettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(PBL4Settings.MySetting1));
        }
    }
}
