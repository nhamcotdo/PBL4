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
        public static IHost Host;
        public static string Token;

        public static string ServerName()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            string url = appSettings["ServerName"];
            return url;
        }

        public static string UserName()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            string url = appSettings["UserName"];
            return url;
        }

        public static string Password()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            string url = appSettings["Password"];
            return url;
        }

        public static string DatabaseName()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            string url = appSettings["DatabaseName"];
            return url;
        }

        public static string PathDesignUI()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            string url = appSettings["PathDesignUI"];
            return url;
        }

        public static string NamespareProject()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            string url = appSettings["NamespareProject"];
            return url;
        }

        public static string NamespareSDK()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            string url = appSettings["NamespareSDK"];
            return url;
        }

        public static string NamespareService()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            string url = appSettings["NamespareService"];
            return url;
        }

        public static string NamespareSchema()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            string url = appSettings["NamespareSchema"];
            return url;
        }

        public static string PathGenerate()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            string url = appSettings["PathGenerate"];
            return url;
        }

        public static string PathTemplate()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            return Application.StartupPath + appSettings["PathTemplate"] + @"Excel\";
        }

        public static string PathGridViewXML()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            return Application.StartupPath + appSettings["PathTemplate"] + @"GridViewXML\";
        }

        public static string PathTreeListXML()
        {
            NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            return Application.StartupPath + appSettings["PathTemplate"] + @"TreeListXML\";
        }

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
