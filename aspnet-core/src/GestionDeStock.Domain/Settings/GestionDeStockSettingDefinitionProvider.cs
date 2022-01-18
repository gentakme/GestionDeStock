using Volo.Abp.Settings;

namespace GestionDeStock.Settings
{
    public class GestionDeStockSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(GestionDeStockSettings.MySetting1));
        }
    }
}
