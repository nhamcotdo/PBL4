using PBL4_Winform.ConfigManagers;
using PBL4_Winform.Dto;
using PBL4_Winform.Dto.LessonCompletes;
using PBL4_Winform.Dto.Students;
using PBL4_Winform.Dto.User;
using PBL4_Winform.SdkCommon;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PBL4_Winform.View.Students
{
    public partial class StudentDetail : Form
    {
        public delegate void MyDel(string filter = "");
        public MyDel f { get; set; }

        private readonly IStudentApi studentApi;
        private Guid studentId;
        private string _mode { get; set; }

        public StudentDetail(Guid id = new Guid(), string mode = "VIEW")
        {
            InitializeComponent();
            _mode = mode;
            studentApi = ConfigManager.GetAPIByService<IStudentApi>();
            cbShowPassword.Checked = false;

            if (mode == "CREATE")
            {
                cbbClass.Enabled = false;
                btnSubmit.Text = "Tạo mới";

                return;
            }

            var studentDto = studentApi.GetAsync(id).GetAwaiter().GetResult();
            studentId = id;
            txtName.Text = studentDto.UserLogin.Name;
            txtAddress.Text = studentDto.UserLogin.Address;
            dtpBirthdate.Value = studentDto.UserLogin.BirthDate;
            txtParentName.Text = studentDto.ParentName;
            txtPhoneNumber.Text = studentDto.UserLogin.PhoneNumber;
            txtNote.Text = studentDto.UserLogin.Note;
            txtUserName.Text = studentDto.UserLogin.UserName;
            txtPassword.Text = studentDto.UserLogin.Password;
            cbbClass.DataSource = studentDto.Registers.Select(x => new CBBItem
            {
                Value = x.ClassId,
                Text = x.Class.Name
            }).ToList();
            cbbClass.DisplayMember = "Text";
            if (cbbClass.Items.Count > 0)
                cbbClass.SelectedIndex = 0;
            btnSubmit.Text = "Chỉnh sửa";

            if (mode == "VIEW")
            {
                txtName.Enabled = false;
                txtAddress.Enabled = false;
                dtpBirthdate.Enabled = false;
                txtParentName.Enabled = false;
                txtPhoneNumber.Enabled = false;
                txtNote.Enabled = false;
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                btnSubmit.Text = "Đóng";
            }
        }

        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbClass.Items.Count > 0)
            {
                dgvLesson.Rows.Clear();
                dgvLesson.Refresh();
                var lessons = studentApi.GetLessonByClassId(studentId, (cbbClass.SelectedItem as CBBItem).Value)
                                             .GetAwaiter()
                                             .GetResult()
                                             .Select(x => new LessonView
                                             {
                                                 LessonName = x.Lesson?.Title,
                                                 IsComplete = x.IsComplete,
                                                 Comment = x.Comment
                                             })
                                             .ToList();

                foreach (var lesson in lessons)
                {
                    dgvLesson.Rows.Add(lesson.LessonName, true, lesson.Comment);
                }
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as System.Windows.Forms.CheckBox).Checked)
                txtPassword.PasswordChar = (char)0;
            else
                txtPassword.PasswordChar = '*';
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_mode == "CREATE")
            {
                var student = studentApi.CreateAsync(new CreateUpdateStudentDto
                {
                    ParentName = txtParentName.Text,
                    UserLogin = new CreateUpdateUserLoginDto
                    {
                        UserName = txtUserName.Text,
                        Password = txtPassword.Text,
                        Name = txtName.Text,
                        BirthDate = dtpBirthdate.Value,
                        PhoneNumber = txtPhoneNumber.Text,
                        Address = txtAddress.Text,
                        Note = lbNote.Text
                    }
                }).GetAwaiter().GetResult();

                if (student != null)
                {
                    var result = MessageBox.Show("Thêm học sinh " + student.UserLogin.Name + " thành công!");
                    if (result == DialogResult.OK)
                    {
                        f();
                    }
                }
                else
                {
                    var result = MessageBox.Show("Thêm học sinh không thành công!");
                }
            }
            else if (_mode == "EDIT")
            {
                var student = studentApi.UpdateAsync(studentId, new CreateUpdateStudentDto
                {
                    ParentName = txtParentName.Text,
                    UserLogin = new CreateUpdateUserLoginDto
                    {
                        UserName = txtUserName.Text,
                        Password = txtPassword.Text,
                        Name = txtName.Text,
                        BirthDate = dtpBirthdate.Value,
                        PhoneNumber = txtPhoneNumber.Text,
                        Address = txtAddress.Text,
                        Note = lbNote.Text
                    }
                }).GetAwaiter().GetResult();
                f();
            }

            this.Close();
        }
    }
}
