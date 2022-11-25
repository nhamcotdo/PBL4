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

namespace PBL4_Winform.View.Courses
{
    public partial class Lessons : Form
    {
        public delegate void MyDel(List<DataRow> lessons);
        public MyDel f { get; set; }
        private DataTable dt = new DataTable();

        private ILessonApi apiLesson { get; set; }

        public Lessons()
        {
            apiLesson = ConfigManager.GetAPIByService<ILessonApi>();
            InitializeComponent();
            LoadLessons();
        }
        public void LoadLessons(string filter = "")
        {
            var lessonDtos = apiLesson.SearchAsync(filter)
                                                 .GetAwaiter()
                                                 .GetResult().Items;

            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(Guid)),
                new DataColumn("Tên bài học", typeof(string)),
                new DataColumn("Link tài liệu", typeof(string)),
                new DataColumn("Thời gian(giờ)", typeof(float)),
                });

            foreach (var lesson in lessonDtos)
            {
                dt.Rows.Add(lesson.Id, lesson.Title, lesson.DocumentUrl, lesson.TimePerLesson);
            }
            dgvLesson.DataSource = dt;

            dgvLesson.ReadOnly = true;
        }

        private void btnSearchLesson_Click(object sender, EventArgs e)
        {
            LoadLessons(txtSearchLesson.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var lessons = new List<DataRow>();

            foreach (DataGridViewRow row in dgvLesson.SelectedRows)
            {
                lessons.Add(dt.Rows[row.Index]);
            }

            f(lessons);
            this.Dispose();
        }
    }
}
