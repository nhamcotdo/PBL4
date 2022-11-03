using PBL4_Winform.ConfigManagers;
using PBL4_Winform.SdkCommon;
using PBL4_Winform.View.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.View
{
    public partial class Mainform : Form
    {
        private IStudentApi apiStudent { get; set; }
        private ICourseApi apiCourse { get; set; }
        private ILessonApi apiLesson { get; set; }

        public Mainform()
        {
            apiStudent = ConfigManager.GetAPIByService<IStudentApi>();
            apiLesson = ConfigManager.GetAPIByService<ILessonApi>();
            apiCourse = ConfigManager.GetAPIByService<ICourseApi>();
            InitializeComponent();
            //var frmLogin = new LoginForm();
            //frmLogin.ShowDialog();
            LoadStudents();
            LoadLessons();
        }

        //Student
        private void LoadStudents(string filter = "")
        {
            var studentDtos = apiStudent.SearchAsync(filter)
                                                 .GetAwaiter()
                                                 .GetResult();
            dgvStudent.DataSource = studentDtos.Items.Select(x => new
            {
                Id = x.Id,
                Name = x.UserLogin.Name,
                ParentName = x.ParentName,
                BirthDate = x.UserLogin.BirthDate,
                PhoneNumber = x.UserLogin.PhoneNumber,
                Address = x.UserLogin.Address,
                Note = x.UserLogin.Note
            }).ToList();
        }

        private void dgvStudent_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Guid id = (Guid)dgvStudent.Rows[e.RowIndex].Cells[0].Value;
                (new StudentDetail(id, mode: "VIEW")).Show();
            }
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count == 1)
            {
                Guid id = (Guid)dgvStudent.SelectedRows[0].Cells[0].Value;
                var studentDetail = new StudentDetail(id: id, mode: "EDIT");
                studentDetail.f = LoadStudents;
                studentDetail.Show();
            }
        }

        private void btnCreateStudent_Click(object sender, EventArgs e)
        {
            var studentDetail = new StudentDetail(mode: "CREATE");
            studentDetail.f = LoadStudents;
            studentDetail.Show();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count <= 0)
                return;

            var result = MessageBox.Show("Bạn có chắc chắn muốn xoá những học sinh này ?");
            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow student in dgvStudent.SelectedRows)
                {
                    apiStudent.DeleteAsync(Guid.Parse(student.Cells[0].Value.ToString()));
                }
                LoadStudents();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStudents(txtSearch.Text);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoadStudents(txtSearch.Text);
            }
        }

        //Course
        public void LoadCourses()
        {

        }

        //Lesson
        public void LoadLessons(string filter = "")
        {
            var lessonDtos = apiLesson.SearchAsync(filter)
                                                 .GetAwaiter()
                                                 .GetResult();
            dgvLesson.DataSource = lessonDtos.Items.Select(x => new
            {
                Title = x.Title,
                DocumentUrl = x.DocumentUrl,
                TimePerLesson = x.TimePerLesson,
                Guide = x.Guide
            }).ToList();
        }

        private void btnSearchLesson_Click(object sender, EventArgs e)
        {
            LoadLessons(txtSearchLesson.Text);
        }

        private void txtSearchLesson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoadLessons(txtSearchLesson.Text);
            }
        }
    }
}
