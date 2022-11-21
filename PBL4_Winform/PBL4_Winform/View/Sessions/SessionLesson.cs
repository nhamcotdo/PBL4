using PBL4_Winform.ConfigManagers;
using PBL4_Winform.SdkCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace PBL4_Winform.View.Sessions
{
    public partial class SessionLesson : Form
    {
        public delegate void UpdateLesson(int rowindex, string lessonName, Guid lessonId);
        public UpdateLesson updateLesson;

        private ILessonApi apiLesson { get; set; }
        private DataTable dtLesson = new DataTable();
        private readonly Guid _classId;
        private readonly Guid _studentId;
        private readonly int _row;
        public SessionLesson(Guid classId, Guid studentId, int row)
        {
            InitializeComponent();
            apiLesson = ConfigManager.GetAPIByService<ILessonApi>();
            this._classId = classId;
            this._studentId = studentId;
            this._row = row;

            LoadLessons();
        }
        public void LoadLessons(string filter = "")
        {
            var lessonDtos = apiLesson.GetListByStudentIdAndClassId(_classId, _studentId)
                                                 .GetAwaiter()
                                                 .GetResult();

            dtLesson.Rows.Clear();
            dtLesson.Columns.Clear();
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

        private void btnAddLesson_Click(object sender, EventArgs e)
        {
            if(dgvLesson.SelectedRows.Count == 1)
            {
                updateLesson(_row, dgvLesson.SelectedRows[0].Cells[1].Value.ToString(), Guid.Parse(dgvLesson.SelectedRows[0].Cells[0].Value.ToString()));
                this.Close();
            }
        }
    }
}
