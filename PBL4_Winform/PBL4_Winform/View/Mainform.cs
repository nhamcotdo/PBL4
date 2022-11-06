using PBL4_Winform.ConfigManagers;
using PBL4_Winform.SdkCommon;
using PBL4_Winform.View.Courses;
using PBL4_Winform.View.Lessons;
using PBL4_Winform.View.Students;
using System;
using System.Data;
using System.Windows.Forms;

namespace PBL4_Winform.View
{
    public partial class Mainform : Form
    {
        private IStudentApi apiStudent { get; set; }
        private ICourseApi apiCourse { get; set; }
        private ILessonApi apiLesson { get; set; }
        private IClassApi apiClass { get; set; }

        private DataTable dtStudent = new DataTable();
        private DataTable dtCourse = new DataTable();
        private DataTable dtLesson = new DataTable();
        private DataTable dtClass = new DataTable();

        public Mainform()
        {
            apiStudent = ConfigManager.GetAPIByService<IStudentApi>();
            apiLesson = ConfigManager.GetAPIByService<ILessonApi>();
            apiCourse = ConfigManager.GetAPIByService<ICourseApi>();
            apiClass = ConfigManager.GetAPIByService<IClassApi>();
            InitializeComponent();
            //var frmLogin = new LoginForm();
            //frmLogin.ShowDialog();
            AddHeader();
            LoadStudents();
            LoadLessons();
            LoadCourses();
            LoadClass();
        }

        private void AddHeader()
        {
            dtStudent.Columns.AddRange(new DataColumn[]
           {
                new DataColumn("Id",typeof(Guid)),
                new DataColumn("Tên",typeof(string)),
                new DataColumn("Tên phụ huynh", typeof(string)),
                new DataColumn("Ngày sinh", typeof(DateTime)),
                new DataColumn("Số điện thoại", typeof(string)),
                new DataColumn("Địa chỉ", typeof(string)),
                new DataColumn("Ghi chú", typeof(string)),
           });

            dtLesson.Columns.AddRange(
               new DataColumn[]
               {
                    new DataColumn("ID", typeof(Guid)),
                    new DataColumn("Tên bài học", typeof(string)),
                    new DataColumn("Link tài liệu", typeof(string)),
                    new DataColumn("Thời gian mỗ buổi học", typeof(float)),
                    new DataColumn("Hướng dẫn", typeof(string)),
               }
           );

            dtCourse.Columns.AddRange(
            new DataColumn[]
            {
                    new DataColumn("ID", typeof(Guid)),
                    new DataColumn("Họ tên", typeof(string)),
                    new DataColumn("Mô tả", typeof(string)),
                    new DataColumn("Số lượng buổi học", typeof(float)),
            }
        );

            dtClass.Columns.AddRange(
            new DataColumn[]
            {
                    new DataColumn("ID", typeof(Guid)),
                    new DataColumn("Tên", typeof(string)),
                    new DataColumn("Thời gian bắt đầu", typeof(DateTime)),
                    new DataColumn("Thời gian Kết thúc", typeof(DateTime)),
                    new DataColumn("Học phí", typeof(float)),
                    new DataColumn("Tên khoá học", typeof(string)),
                    new DataColumn("Tên kì học", typeof(string)),
            }
        );
        }

        //Student
        private void LoadStudents(string filter = "")
        {
            var studentDtos = apiStudent.SearchAsync(filter)
                                                 .GetAwaiter()
                                                 .GetResult().Items;
            dtStudent.Rows.Clear();
            foreach (var student in studentDtos)
            {
                dtStudent.Rows.Add(
                    student.Id,
                    student.UserLogin.Name,
                    student.ParentName,
                    student.UserLogin.BirthDate,
                    student.UserLogin.PhoneNumber,
                    student.UserLogin.Address,
                    student.UserLogin.Note
                    );
            }

            dgvStudent.DataSource = dtStudent;
            dgvStudent.Columns[0].Visible = false;
            dgvStudent.ReadOnly = true;
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
            var count = dgvStudent.SelectedRows.Count;
            var result = MessageBox.Show("Bạn có chắc chắn muốn xoá " + count + " học sinh này ?");
            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow student in dgvStudent.SelectedRows)
                {
                    apiStudent.DeleteAsync(Guid.Parse(student.Cells[0].Value.ToString()));
                }
                MessageBox.Show("Đã xoá thành công " + count + " học sinh!");
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


        //Lesson
        public void LoadLessons(string filter = "")
        {
            var lessonDtos = apiLesson.SearchAsync(filter)
                                                 .GetAwaiter()
                                                 .GetResult().Items;

            dtLesson.Rows.Clear();

            foreach (var lesson in lessonDtos)
            {
                dtLesson.Rows.Add(
                    lesson.Id,
                    lesson.Title,
                    lesson.DocumentUrl,
                    lesson.TimePerLesson,
                    lesson.Guide
                );
            }

            dgvLesson.DataSource = dtLesson;
            dgvLesson.Columns[0].Visible = false;
            dgvLesson.ReadOnly = true;
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

        private void btnAddLesson_Click(object sender, EventArgs e)
        {
            var lessonDetail = new LessonDetail(mode: "CREATE");
            lessonDetail.f = LoadLessons;
            lessonDetail.Show();
        }

        private void btnEditLesson_Click(object sender, EventArgs e)
        {
            if (dgvLesson.SelectedRows.Count == 1)
            {
                Guid id = (Guid)dgvLesson.SelectedRows[0].Cells[0].Value;
                var lessonDetail = new LessonDetail(id: id, mode: "EDIT");
                lessonDetail.f = LoadLessons;
                lessonDetail.Show();
            }
        }

        private void btnDeleteLesson_Click(object sender, EventArgs e)
        {
            if (dgvLesson.SelectedRows.Count <= 0)
                return;
            var count = dgvLesson.SelectedRows.Count;
            var result = MessageBox.Show("Bạn có chắc chắn muốn xoá " + count + " bài học này ?");
            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow lesson in dgvLesson.SelectedRows)
                {
                    apiLesson.DeleteAsync(Guid.Parse(lesson.Cells[0].Value.ToString())).GetAwaiter();
                }
                MessageBox.Show("Đã xoá thành công " + count + " bài học!");
                LoadLessons();
            }
        }

        //Course
        public void LoadCourses(string filter = "")
        {
            var courseDtos = apiCourse.SearchAsync(filter).GetAwaiter().GetResult().Items;

            dtCourse.Rows.Clear();
            foreach (var course in courseDtos)
            {
                dtCourse.Rows.Add(
                    course.Id,
                    course.Name,
                    course.Description,
                    course.NumberOfLesson
                );
            }

            dgvCourse.DataSource = dtCourse;
            dgvCourse.Columns[0].Visible = false;
            dgvCourse.ReadOnly = true;
        }

        private void btnSearchCourse_Click(object sender, EventArgs e)
        {
            LoadCourses(txtSearchCourse.Text);
        }

        private void txtSearchCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoadCourses(txtSearchCourse.Text);
            }
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            var courseDetail = new CourseDetail(mode: "CREATE");
            courseDetail.f = LoadCourses;
            courseDetail.Show();
        }

        private void btnEditCourse_Click(object sender, EventArgs e)
        {
            if (dgvCourse.SelectedRows.Count == 1)
            {
                Guid id = (Guid)dgvCourse.SelectedRows[0].Cells[0].Value;
                var courseDetail = new CourseDetail(id: id, mode: "EDIT");
                courseDetail.f = LoadCourses;
                courseDetail.Show();
            }
        }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (dgvCourse.SelectedRows.Count <= 0)
                return;

            var count = dgvCourse.SelectedRows.Count;

            var result = MessageBox.Show("Bạn có chắc chắn muốn xoá " + count + " bài học này ?");
            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow course in dgvCourse.SelectedRows)
                {
                    apiCourse.DeleteAsync(Guid.Parse(course.Cells[0].Value.ToString())).GetAwaiter();
                }
            }
            MessageBox.Show("Đã xoá thành công " + count + " khoá học!");
            LoadCourses();
        }

        private void dgvStudent_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Guid id = (Guid)dgvStudent.Rows[e.RowIndex].Cells[0].Value;
                (new StudentDetail(id, mode: "VIEW")).Show();
            }
        }

        private void dgvLesson_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Guid id = (Guid)dgvLesson.Rows[e.RowIndex].Cells[0].Value;
                (new LessonDetail(id, mode: "VIEW")).Show();
            }
        }

        private void dgvCourse_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Guid id = (Guid)dgvCourse.Rows[e.RowIndex].Cells[0].Value;
                (new CourseDetail(id, mode: "VIEW")).Show();
            }
        }

        //Class
        public void LoadClass(string filter = "")
        {
            var classDtos = apiClass.SearchAsync(filter).GetAwaiter().GetResult().Items;

            dtCourse.Rows.Clear();
            foreach (var classDto in classDtos)
            {
                dtClass.Rows.Add(
                    classDto.Id,
                    classDto.Name,
                    classDto.StartTime,
                    classDto.EndTime,
                    classDto.Course.Name,
                    classDto.Term.Name
                );
            }

            dgvClass.DataSource = dtClass;
            dgvClass.Columns[0].Visible = false;
            dgvClass.ReadOnly = true;
        }

        private void btnSearchClass_Click(object sender, EventArgs e)
        {

        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {

        }

        private void btnEditClass_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchClass_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvClass_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            if (dgvClass.SelectedRows.Count <= 0)
                return;
            var count = dgvClass.SelectedRows.Count;
            var result = MessageBox.Show("Bạn có chắc chắn muốn xoá " + count + " học sinh này ?");
            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dgvClass.SelectedRows)
                {
                    apiClass.DeleteAsync(Guid.Parse(row.Cells[0].Value.ToString()));
                }
                MessageBox.Show("Đã xoá thành công " + count + " lớp học!");
                LoadClass();
            }
        }
    }
}
