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
            // myGroup.AddPermission(PBL4Permissions.Update, L("Cập nhật"));
            // myGroup.AddPermission(PBL4Permissions.Create, L("Tạo mới"));
            // myGroup.AddPermission(PBL4Permissions.View, L("Xem"));
            // myGroup.AddPermission(PBL4Permissions.Delete, L("Xoá"));

            var classPermission = myGroup.AddPermission(PBL4Permissions.Class.Default, L("Permission:Class"));
            classPermission.AddChild(PBL4Permissions.Class.Create, L("Permission:Create"));
            classPermission.AddChild(PBL4Permissions.Class.Update, L("Permission:Update"));
            classPermission.AddChild(PBL4Permissions.Class.Delete, L("Permission:Delete"));
            classPermission.AddChild(PBL4Permissions.Class.Get, L("Permission:Get"));

            var coursePermission = myGroup.AddPermission(PBL4Permissions.Course.Default, L("Permission:Course"));
            coursePermission.AddChild(PBL4Permissions.Course.Create, L("Permission:Create"));
            coursePermission.AddChild(PBL4Permissions.Course.Update, L("Permission:Update"));
            coursePermission.AddChild(PBL4Permissions.Course.Delete, L("Permission:Delete"));
            coursePermission.AddChild(PBL4Permissions.Course.Get, L("Permission:Get"));

            var lessonPermission = myGroup.AddPermission(PBL4Permissions.Lesson.Default, L("Permission:Lesson"));
            lessonPermission.AddChild(PBL4Permissions.Lesson.Create, L("Permission:Create"));
            lessonPermission.AddChild(PBL4Permissions.Lesson.Update, L("Permission:Update"));
            lessonPermission.AddChild(PBL4Permissions.Lesson.Delete, L("Permission:Delete"));
            lessonPermission.AddChild(PBL4Permissions.Lesson.Get, L("Permission:Get"));

            var studentPermission = myGroup.AddPermission(PBL4Permissions.Student.Default, L("Permission:Student"));
            studentPermission.AddChild(PBL4Permissions.Student.Create, L("Permission:Create"));
            studentPermission.AddChild(PBL4Permissions.Student.Update, L("Permission:Update"));
            studentPermission.AddChild(PBL4Permissions.Student.Delete, L("Permission:Delete"));
            studentPermission.AddChild(PBL4Permissions.Student.Get, L("Permission:Get"));

            var sessionPermission = myGroup.AddPermission(PBL4Permissions.Session.Default, L("Permission:Session"));
            sessionPermission.AddChild(PBL4Permissions.Session.Create, L("Permission:Create"));
            sessionPermission.AddChild(PBL4Permissions.Session.Update, L("Permission:Update"));
            sessionPermission.AddChild(PBL4Permissions.Session.Delete, L("Permission:Delete"));
            sessionPermission.AddChild(PBL4Permissions.Session.Get, L("Permission:Get"));

            var termPermission = myGroup.AddPermission(PBL4Permissions.Term.Default, L("Permission:Term"));
            termPermission.AddChild(PBL4Permissions.Term.Create, L("Permission:Create"));
            termPermission.AddChild(PBL4Permissions.Term.Update, L("Permission:Update"));
            termPermission.AddChild(PBL4Permissions.Term.Delete, L("Permission:Delete"));
            termPermission.AddChild(PBL4Permissions.Term.Get, L("Permission:Get"));
        }


        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PBL4Resource>(name);
        }
    }
}
