using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Refit;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL4_Winform.ConfigManagers
{
    public static class ConfigManager
    {
        public static IConfigurationRoot Configuration;
        //public static IHost Host;
        public static string Token;

        public static string RemoteAPIURL()
        {
            return Configuration.GetSection("RemoteServices:Default:BaseUrl").Value;
        }

        public static T GetAPIByService<T>()
        {
            string token = string.IsNullOrWhiteSpace(Token) ? string.Empty : Token;
            T obj = RestService.For<T>(RemoteAPIURL(),
              new RefitSettings
              {
                  CollectionFormat = CollectionFormat.Multi,
                  AuthorizationHeaderValueGetter = () => Task.FromResult(token)
              });
              
            return obj;
        }
    }
}
