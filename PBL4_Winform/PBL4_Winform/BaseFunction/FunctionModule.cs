using System;
using PBL4_Winform.ConfigManagers;
using Volo.Abp.Identity;
using Volo.Abp.Data;
using PBL4_Winform.SdkCommon;
using System.Linq;

namespace PBL4_Winform.BaseFunction
{
    public class FunctionModule
    {
        public static IdentityUserDto UserDto;
        public static String CurrentUser = "Khách";
        public static string CurrentRole;
        public static Guid CurrentRoleId;

        public static bool SetCurrentUserLogin(String strUserName)
        {
            CurrentUser = "Khách";
            //MainScreen._txtUserName.Text = strUserName;
            try
            {
                var apiUser = ConfigManager.GetAPIByService<IUsersApi>();
                UserDto = apiUser.GetByUserName(strUserName).GetAwaiter().GetResult();
                IdentityRoleDto identityRoleDto = apiUser.GetDataRoleById(UserDto.Id).GetAwaiter().GetResult().Items.First();
                var tenVaiTro = identityRoleDto.Name;
                var vaiTroId = identityRoleDto.Id;
                string name = UserDto.Name;
               
                CurrentUser =  name + " - " + tenVaiTro;
             
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
