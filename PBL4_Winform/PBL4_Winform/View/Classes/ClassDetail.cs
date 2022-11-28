using PBL4_Winform.ConfigManagers;
using PBL4_Winform.Dto;
using PBL4_Winform.Dto.Classes;
using PBL4_Winform.SdkCommon;
using PBL4_Winform.SdkCommon.Terms;
using Refit;
using System;
using System.Linq;
using System.Windows.Forms;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.View.Classes
{
    public partial class ClassDetail : Form
    {
        public delegate void MyDel(string filter = "");
        public MyDel f { get; set; }

        private readonly IClassApi classApi;
        private readonly ICourseApi courseApi;
        private readonly ITermApi termApi;

        private Guid classId;
        private string _mode { get; set; }

        public ClassDetail(Guid id = new Guid(), string mode = "VIEW")
        {
            classApi = ConfigManager.GetAPIByService<IClassApi>();
            courseApi = ConfigManager.GetAPIByService<ICourseApi>();
            termApi = ConfigManager.GetAPIByService<ITermApi>();
            _mode = mode;
            classId = id;
            InitializeComponent();
            cbbCourseName.DataSource = courseApi.GetListAsync(new PagedAndSortedResultRequestDto())
                                                .GetAwaiter()
                                                .GetResult()
                                                .Items
                                                .Select(
                                                    x => new CBBItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.Id
                                                    }
                                                    ).ToList();
            cbbTermName.DataSource = termApi.GetListAsync(new PagedAndSortedResultRequestDto())
                                                .GetAwaiter()
                                                .GetResult()
                                                .Items
                                                .Select(
                                                    x => new CBBItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.Id
                                                    }
                                                    ).ToList();
            cbbCourseName.DisplayMember = "Text";
            cbbTermName.DisplayMember = "Text";

            if (mode == "CREATE")
            {
                btnSubmit.Text = "Tạo mới";
                return;
            }

            var classDto = classApi.GetAsync(id).GetAwaiter().GetResult();
            txtName.Text = classDto.Name;
            rtDecription.Text = classDto.Description;
            dtpStart.Value = classDto.StartTime;
            dtpEnd.Value = classDto.EndTime;
            cbbCourseName.Text = classDto.Course?.Name;
            cbbTermName.Text = classDto.Term?.Name;
            nbFee.Text = classDto.Fee.ToString();

            btnSubmit.Text = "Sửa";

            if (mode == "VIEW")
            {
                txtName.Enabled = false;
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                rtDecription.ReadOnly = true;
                cbbCourseName.Enabled = false;
                cbbTermName.Enabled = false;
                nbFee.Enabled = false;
                btnSubmit.Text = "Đóng";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_mode == "CREATE")
            {
                var classDto = classApi.CreateAsync(
                    new CreateUpdateClassDto
                    {
                        Name = txtName.Text,
                        Description = rtDecription.Text,
                        StartTime = dtpStart.Value,
                        EndTime = dtpEnd.Value,
                        CourseId = (cbbCourseName.SelectedValue as CBBItem).Value,
                        TermId = (cbbTermName.SelectedValue as CBBItem).Value,
                        Fee = float.Parse(nbFee.Text)
                    }).GetAwaiter().GetResult();
                if (classDto != null)
                {
                    var rs = MessageBox.Show("Thêm bài học " + classDto.Name + " thành công!");
                    if (rs == DialogResult.OK)
                    {
                        f();
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi tạo bài học mới!");
                }
            }
            else if (_mode == "EDIT")
            {
                ClassDto classDto = null;
              
                    classDto = classApi.UpdateAsync(classId,
                    new CreateUpdateClassDto
                    {
                        Name = txtName.Text,
                        Description = rtDecription.Text,
                        StartTime = dtpStart.Value,
                        EndTime = dtpEnd.Value,
                        CourseId = (cbbCourseName.SelectedValue as CBBItem).Value,
                        TermId = (cbbTermName.SelectedValue as CBBItem).Value,
                        Fee = float.Parse(nbFee.Text)
                    }).GetAwaiter().GetResult();
             
                             if (classDto != null)
                {
                    var rs = MessageBox.Show("Cập nhật lớp học " + classDto.Name + " thành công!");
                    if (rs == DialogResult.OK)
                    {
                        f();
                    }
                }
            }
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
