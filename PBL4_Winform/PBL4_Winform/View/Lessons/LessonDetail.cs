using PBL4_Winform.ConfigManagers;
using PBL4_Winform.Dto.Lessons;
using PBL4_Winform.SdkCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL4_Winform.View.Lessons
{
    public partial class LessonDetail : Form
    {
        public delegate void MyDel(string filter = "");
        public MyDel f { get; set; }

        private readonly ILessonApi lessonApi;
        private Guid lessonId;
        private string _mode { get; set; }

        public LessonDetail(Guid id = new Guid(), string mode = "VIEW")
        {
            lessonApi = ConfigManager.GetAPIByService<ILessonApi>();
            _mode = mode;
            lessonId = id;
            InitializeComponent();


            if (mode == "CREATE")
            {
                btnSubmit.Text = "Tạo mới";

                return;
            }

            var lessonDto = lessonApi.GetAsync(id).GetAwaiter().GetResult();
            txtTitle.Text = lessonDto.Title;
            txtDocumentUrl.Text = lessonDto.DocumentUrl;
            nbTimePerLesson.Value = (decimal)lessonDto.TimePerLesson;
            rtGuide.Text = lessonDto.Guide;

            if (mode == "VIEW")
            {
                txtDocumentUrl.Enabled = false;
                txtTitle.Enabled = false;
                nbTimePerLesson.Enabled = false;
                rtGuide.ReadOnly = true;
            }
        }

        private void linkDocumentUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkDocumentUrl.LinkVisited = true;
            try
            {
                System.Diagnostics.Process.Start(txtDocumentUrl.Text);
            }
            catch
            {
                MessageBox.Show("Link không hợp lệ!");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_mode == "CREATE")
            {
                var lessonDto = lessonApi.CreateAsync(
                    new CreateUpdateLessonDto
                    {
                        Title = txtTitle.Text,
                        DocumentUrl = txtDocumentUrl.Text,
                        TimePerLesson = (float)nbTimePerLesson.Value,
                        Guide = rtGuide.Text
                    }).GetAwaiter().GetResult();
                if(lessonDto != null)
                {
                    var rs = MessageBox.Show("Thêm bài học "+ lessonDto.Title +" thành công!");
                    if(rs == DialogResult.OK)
                    {
                        f();
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi tạo bài học mới!");
                }
            }
            else if(_mode == "EDIT")
            {
                var lessonDto = lessonApi.UpdateAsync(lessonId,
                    new CreateUpdateLessonDto
                    {
                        Title = txtTitle.Text,
                        DocumentUrl = txtDocumentUrl.Text,
                        TimePerLesson = (float)nbTimePerLesson.Value,
                        Guide = rtGuide.Text
                    }).GetAwaiter().GetResult();
                if (lessonDto != null)
                {
                    var rs = MessageBox.Show("Cập nhật bài học " + lessonDto.Title + " thành công!");
                    if (rs == DialogResult.OK)
                    {
                        f();
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi sửa  đổi bài học mới!");
                }
            }
            this.Close();
        }
    }
}
