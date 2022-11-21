using PBL4_Winform.ConfigManagers;
using PBL4_Winform.Dto.SessionRegisters;
using PBL4_Winform.Dto.Sessions;
using PBL4_Winform.Dto.Student;
using PBL4_Winform.SdkCommon.Sessions;
using PBL4_Winform.View.Courses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PBL4_Winform.View.Sessions
{
    public partial class SessionDetail : Form
    {
        public delegate void MyDel(string filter = "");
        public MyDel f { get; set; }

        private readonly ISessionApi sessionApi;

        private Guid sessionId;
        private string _mode { get; set; }

        DataTable dt = new DataTable();

        public SessionDetail(Guid id = new Guid(), string mode = "VIEW")
        {
            sessionApi = ConfigManager.GetAPIByService<ISessionApi>();
            _mode = mode;
            sessionId = id;

            InitializeComponent();

            dt.Columns.AddRange(
                new DataColumn[]
                {
                    new DataColumn("StudentId", typeof(Guid)),
                    new DataColumn("Tên học sinh", typeof(string)),
                    new DataColumn("ClassId", typeof(Guid)),
                    new DataColumn("Lớp học", typeof(string)),
                    new DataColumn("LessonId", typeof(Guid)),
                    new DataColumn("Bài học", typeof(string)),
                });
            dgvRegisterSession.DataSource = dt;
            dgvRegisterSession.Columns[0].Visible = false;
            dgvRegisterSession.Columns[2].Visible = false;
            dgvRegisterSession.Columns[4].Visible = false;
            dgvRegisterSession.Columns[4].Visible = false;


            if (_mode == "CREATE")
            {

                btnSubmit.Text = "Tạo mới";
                return;
            }


            btnSubmit.Text = "Cập nhật";
            var sessionDto = sessionApi.GetAsync(id).GetAwaiter().GetResult();
            txtName.Text = sessionDto.Name;
            dtpStart.Value = sessionDto.StartTime;
            dtpEnd.Value= sessionDto.EndTime;

            var students = sessionDto.SessionRegisters;

            foreach(var student in students)
            {
                dt.Rows.Add(student.StudentId, student.StudentName, student.ClassId, student.ClassName, student.LessonId, student.LessonName);
            }
            

            if (mode == "VIEW")
            {
                txtName.Enabled = false;
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                btnSubmit.Text = "Đóng";
                btnAdd.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_mode == "VIEW")
            {
                this.Close();
                return;
            }

            var createUpdateSessionRegisterDtos = new List<CreateUpdateSessionRegisterDto>();
            if (dt.Rows.Count > 1)
                foreach (DataRow row in dt.Rows)
                {
                    createUpdateSessionRegisterDtos.Add(new CreateUpdateSessionRegisterDto
                    {
                        StudentId = Guid.Parse(row[0].ToString()),
                        ClassId = Guid.Parse(row[2].ToString()),
                        LessonId = (!row[4].ToString().IsNullOrWhiteSpace()) ? (Guid?)Guid.Parse(row[4].ToString()):null
                    });
                }

            var createUpdateSessionDto = new CreateUpdateSessionDto
            {
                Name =  txtName.Text,
                StartTime = dtpStart.Value,
                EndTime = dtpEnd.Value,
                SessionRegisters = createUpdateSessionRegisterDtos
            };

           

            if (_mode == "CREATE")
            {
                    sessionApi.CreateSessionAsync(createUpdateSessionDto).GetAwaiter().GetResult();
                    var rs = MessageBox.Show("Thêm bài học thành công!");
                    if (rs == DialogResult.OK)
                    {
                        f();
                    }
            }
            else
            {
                var sessionDto = sessionApi.UpdateAsync(sessionId, createUpdateSessionDto).GetAwaiter().GetResult();
                if (sessionDto != null)
                {
                    var rs = MessageBox.Show("Cập nhật bài học " + sessionDto.Name + " thành công!");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StudentClass f = new StudentClass();
            f.f = addStudent;
            f.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvRegisterSession.SelectedRows.Count >0)
            {
                Int32 selectedRowCount = dgvRegisterSession.Rows.GetRowCount(DataGridViewElementStates.Selected);

                for (int i = 0; i < selectedRowCount; i++)
                {
                    dgvRegisterSession.Rows.RemoveAt(dgvRegisterSession.SelectedRows[0].Index);
                }
            }
        }

        private void addStudent(List<SessionRegisterSimple> students)
        {

            foreach (var student in students)
            {
                if (!dt.AsEnumerable().Any(r => r["StudentId"].ToString() == student.StudentId.ToString()))

                    dt.Rows.Add(student.StudentId, student.StudentName, student.ClassId, student.ClassName);
            }
        }

        private void updateLesson(int rowindex, string lessonName, Guid lessonId)
        {
            dt.Rows[rowindex][4] = lessonId;
            dt.Rows[rowindex][5] = lessonName;
        }

        private void dgvRegisterSession_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5 && e.RowIndex > -1)
            {
                SessionLesson f = new SessionLesson(Guid.Parse(dt.Rows[e.RowIndex][2].ToString()), Guid.Parse(dt.Rows[e.RowIndex][0].ToString()), e.RowIndex);
                f.updateLesson = updateLesson;
                f.Show();
            }
        }
    }
}
