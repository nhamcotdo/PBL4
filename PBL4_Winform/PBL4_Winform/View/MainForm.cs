using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL4_Winform.ConfigManagers;
using PBL4_Winform.SdkCommon;

namespace PBL4_Winform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            var frmLogin = new LoginForm();
            frmLogin.ShowDialog();

            var apiActivity = ConfigManager.GetAPIByService<IActivitiesApi>();
            var acts = apiActivity.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto()).GetAwaiter().GetResult();
        }
    }
}
