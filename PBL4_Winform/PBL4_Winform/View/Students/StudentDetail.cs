using PBL4_Winform.ConfigManagers;
using PBL4_Winform.Dto;
using PBL4_Winform.Dto.LessonCompletes;
using PBL4_Winform.SdkCommon;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PBL4_Winform.View.Students
{
    public partial class StudentDetail : Form
    {
        private readonly IStudentApi studentApi;

        private Guid studentId;
        public StudentDetail(Guid id, bool editable = false)
        {
            InitializeComponent();
            studentId = id;
            studentApi = ConfigManager.GetAPIByService<IStudentApi>();
            var studentDto = studentApi.GetAsync(id).GetAwaiter().GetResult();

            txtName.Text = studentDto.UserLogin.Name;
            txtName.Enabled = editable;
            txtAddress.Text = studentDto.UserLogin.Address;
            txtAddress.Enabled = editable;
            dtpBirthdate.Value = studentDto.UserLogin.BirthDate;
            dtpBirthdate.Enabled = editable;
            txtParentName.Text = studentDto.ParentName;
            txtParentName.Enabled = editable;
            txtPhoneNumber.Text = studentDto.UserLogin.PhoneNumber;
            txtPhoneNumber.Enabled = editable;
            cbbClass.DataSource = studentDto.Registers.Select(x => new CBBItem
            {
                Value = x.ClassId,
                Text = x.Class.Name
            }).ToList();
            cbbClass.DisplayMember = "Text";
            cbbClass.SelectedIndex = 0;
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
                    dgvLesson.Rows.Add(lesson.LessonName,true, lesson.Comment);
                }    
            }
        }
    }
}
