using FormBook.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FormBook.Permissions;

public class FormBookPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FormBookPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(FormBookPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FormBookResource>(name);
    }
}
