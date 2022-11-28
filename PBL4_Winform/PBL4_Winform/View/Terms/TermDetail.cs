using PBL4_Winform.ConfigManagers;
using PBL4_Winform.Dto.Terms;
using PBL4_Winform.SdkCommon.Terms;
using System;
using System.Windows.Forms;

namespace PBL4_Winform.View.Terms
{
    public partial class TermDetail : Form
    {
        public delegate void MyDel(string filter = "");
        public MyDel f { get; set; }

        private readonly ITermApi termApi;

        private Guid termId;
        private string _mode { get; set; }

        public TermDetail(Guid id = new Guid(), string mode = "VIEW")
        {
            termApi = ConfigManager.GetAPIByService<ITermApi>();
            _mode = mode;
            termId = id;

            InitializeComponent();

            if (mode == "CREATE")
            {
                btnSubmit.Text = "Tạo mới";
                return;
            }

            var termDto = termApi.GetAsync(id).GetAwaiter().GetResult();
            txtName.Text = termDto.Name;
            dtpStart.Value = termDto.StartTime;
            dtpEnd.Value= termDto.EndTime;

            if (mode == "VIEW")
            {
                txtName.Enabled = false;
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                btnSubmit.Text = "Đóng";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_mode == "VIEW")
            {
                this.Close();
                return;
            }

            var createUpdateTermDto = new CreateUpdateSessionDto
            {
                Name = txtName.Text,
                StartTime = dtpStart.Value,
                EndTime = dtpEnd.Value,
            };

            if (_mode == "CREATE")
            {
                var termDto = termApi.CreateAsync(createUpdateTermDto).GetAwaiter().GetResult();
                if (termDto != null)
                {
                    var rs = MessageBox.Show("Thêm bài học " + termDto.Name + " thành công!");
                    if (rs == DialogResult.OK)
                    {
                        f();
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi tạo kì học mới!");
                }
            }
            else
            {
                var termDto = termApi.UpdateAsync(termId, createUpdateTermDto).GetAwaiter().GetResult();
                if (termDto != null)
                {
                    var rs = MessageBox.Show("Cập nhật bài học " + termDto.Name + " thành công!");
                    if (rs == DialogResult.OK)
                    {
                        f();
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật kì học!");
                }
            } 
                    
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
