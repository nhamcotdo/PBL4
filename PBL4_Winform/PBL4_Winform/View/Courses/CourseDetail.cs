using PBL4_Winform.ConfigManagers;
using PBL4_Winform.Dto.Courses;
using PBL4_Winform.Dto.Lessons;
using PBL4_Winform.SdkCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PBL4_Winform.View.Courses
{
    public partial class CourseDetail : Form
    {
        public delegate void MyDel(string filter = "");

        public MyDel f { get; set; }

        private DataTable dt = new DataTable();

        private readonly ICourseApi courseApi;

        private Guid courseId;

        private string _mode { get; set; }

        public CourseDetail(Guid id = new Guid(), string mode = "VIEW")
        {
            courseApi = ConfigManager.GetAPIByService<ICourseApi>();
            _mode = mode;
            courseId = id;
            InitializeComponent();
            btnSubmit.Text = "Sửa";

            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(Guid)),
                new DataColumn("Tên bài học", typeof(string)),
                new DataColumn("Link tài liệu", typeof(string)),
                new DataColumn("Thời gian(giờ)", typeof(float))
                });
                dgvLessonOfCourse.DataSource = dt;


            if (_mode == "CREATE")
            {
                btnSubmit.Text = "Tạo mới";

                return;
            }
            try
            {
                var courseDto = courseApi.GetAsync(id).GetAwaiter().GetResult();
                txtName.Text = courseDto.Name;
                rtDescription.Text = courseDto.Description;
                var lessons = courseDto.LessonOfCourses.Select(x => new LessonView
                {
                    Id = x.LessonId,
                    Title = x.Lesson.Title,
                    DocumentUrl = x.Lesson.DocumentUrl,
                    TimePerLesson = x.Lesson.TimePerLesson
                }).ToList();
                    

                foreach (var lesson in lessons)
                {
                    dt.Rows.Add(lesson.Id, lesson.Title, lesson.DocumentUrl, lesson.TimePerLesson);
                }
                dgvLessonOfCourse.DataSource = dt;

                dgvLessonOfCourse.Columns[0].Visible = false;
                dgvLessonOfCourse.ReadOnly = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Vui lòng tải lại trang!");
                this.Close();
            }

            if (mode == "VIEW")
            {
                txtName.Enabled = false;
                rtDescription.ReadOnly = true;
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnSubmit.Text = "Đóng";
            }
        }

        void AddLesson(List<DataRow> lessons)
        {
            foreach (var lesson in lessons)
            {
                if (!dt.AsEnumerable().Any(x => x["ID"].ToString() == lesson[0].ToString()))
                {
                    DataRow dr= dt.NewRow();
                    dt.ImportRow(lesson);
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_mode == "CREATE")
            {
                var lessons = dt.Rows.ToDynamicList().Select(x => new LessonOfCourseDto
                {
                    CourseId = courseId,
                    LessonId = x["Id"],
                }).ToList();
                var courseDto = courseApi.CreateAsync(
                    new CreateUpdateCourseDto
                    {
                        Name = txtName.Text,
                        NumberOfLesson = lessons.Count,
                        Description = rtDescription.Text,
                        LessonOfCourses = lessons
                    }).GetAwaiter().GetResult();
                if (courseDto != null)
                {
                    var rs = MessageBox.Show("Thêm bài học " + courseDto.Name + " thành công!");
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
                var lessons = dt.Rows.ToDynamicList().Select(x => new LessonOfCourseDto
                {
                    CourseId = courseId,
                    LessonId = x["Id"],
                }).ToList();

                var courseDto = courseApi.UpdateAsync(courseId,
                    new CreateUpdateCourseDto
                    {
                        Name = txtName.Text,
                        NumberOfLesson = lessons.Count,
                        Description = rtDescription.Text,
                        LessonOfCourses = lessons
                    }).GetAwaiter().GetResult();

                if (courseDto != null)
                {
                    var rs = MessageBox.Show("Cập nhật khoá học " + courseDto.Name + " thành công!");
                    if (rs == DialogResult.OK)
                    {
                        f();
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi sửa  đổi khoá học!");
                }
            }
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Lessons lessons = new Lessons();
            lessons.f = AddLesson;
            lessons.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvLessonOfCourse.SelectedRows)
            {
                dgvLessonOfCourse.Rows.RemoveAt(row.Index);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}