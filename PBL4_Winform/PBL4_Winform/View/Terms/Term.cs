using PBL4_Winform.ConfigManagers;
using PBL4_Winform.SdkCommon.Terms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL4_Winform.View.Terms
{
    public partial class Term : Form
    {
        public Term()
        {
            InitializeComponent();
            var apiTerm = ConfigManager.GetAPIByService<ITermApi>();
        }
    }
}
