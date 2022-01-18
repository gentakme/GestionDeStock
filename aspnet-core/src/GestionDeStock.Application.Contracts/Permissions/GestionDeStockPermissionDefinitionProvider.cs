using GestionDeStock.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace GestionDeStock.Permissions
{
    public class GestionDeStockPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(GestionDeStockPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(GestionDeStockPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<GestionDeStockResource>(name);
        }
    }
}
