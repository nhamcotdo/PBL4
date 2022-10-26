using System;
using PBL4_Winform.ConfigManagers;
using Volo.Abp.Identity;
using Volo.Abp.Data;
using PBL4_Winform.SdkCommon;

namespace PBL4_Winform.BaseFunction
{
    public class FunctionModule
    {
        public static IdentityUserDto UserDto;
        public static String CurrentUser;
        public static string CurrentRole;
        public static string CurrentRoleId;

        public static bool SetCurrentUserLogin(String strUserName)
        {
            //MainScreen._txtUserName.Text = strUserName;
            try
            {
                var apiUser = ConfigManager.GetAPIByService<IUsersApi>();
                UserDto = apiUser.GetByUserName(strUserName).GetAwaiter().GetResult();
                var tenVaiTro = UserDto.GetProperty<string>("TenVaiTro");
                var vaiTroId = UserDto.GetProperty<string>("VaiTroId");
                string name = UserDto.Name;
                if (tenVaiTro.Contains("admin"))
                {
                    CurrentUser = "admin";
                    name = name + " - " + "Admin";
                }
                else
                {
                    return false;
                }
                CurrentRole = tenVaiTro;
                CurrentRoleId = vaiTroId;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
