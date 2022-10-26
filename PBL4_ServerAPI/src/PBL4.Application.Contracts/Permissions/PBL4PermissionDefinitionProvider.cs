using PBL4.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PBL4.Permissions
{
    public class PBL4PermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(PBL4Permissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(PBL4Permissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PBL4Resource>(name);
        }
    }
}
