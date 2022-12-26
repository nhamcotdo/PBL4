using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Forms;
using PBL4_Winform.ConfigManagers;
using System.Threading;
using Refit;
using System.Net.Http;
using Newtonsoft.Json;

namespace PBL4_Winform
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigManager.Configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);

            Application.Run(new LoginForm());
        }

        public static void UIThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception.GetType() == typeof(ApiException))
            {
                ApiException apiException = (ApiException)e.Exception;
                if(apiException.StatusCode.ToString() == "Forbidden")
                {
                    MessageBox.Show("Bạn không đủ quyền để thực hiện thao tác này");

                    return;
                }
                else if (apiException.StatusCode.ToString() == "NotFound")
                {
                    MessageBox.Show("Thông tin truy cập không tồn tại!");

                    return;
                }
                else if (apiException.StatusCode.ToString() == "BadRequest")
                {
                    MessageBox.Show("Bạn không đủ quyền để thực hiện thao tác này");

                    return;
                }
            }
            else if (e.Exception.GetType() == typeof(HttpRequestException))
            {
                MessageBox.Show("Không thể kết nối đến server hoặc server không hoạt động!");
                Application.Exit();

                return;
            }
            else if(e.Exception.GetType() == typeof(JsonReaderException))
            {
                MessageBox.Show("Bạn cần đăng nhập để thực hiện thao tác này hoặc bạn chưa đủ quyền!");
                (new LoginForm(true)).Show();

                return;
            }
            MessageBox.Show(e.Exception.Message);
        }
    }
}
