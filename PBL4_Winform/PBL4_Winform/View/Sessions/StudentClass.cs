using PBL4_Winform.ConfigManagers;
using PBL4_Winform.Dto;
using PBL4_Winform.Dto.SessionRegisters;
using PBL4_Winform.SdkCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PBL4_Winform.View.Sessions
{
    public partial class StudentClass : Form
    {
        public delegate void MyDel(List<SessionRegisterSimple> l);
        public MyDel f { get; set; }

        private readonly IStudentApi studentApi;
        private readonly IClassApi classApi;

        DataTable dt = new DataTable();
        public StudentClass()
        {
            InitializeComponent();
            studentApi = ConfigManager.GetAPIByService<IStudentApi>();
            classApi = ConfigManager.GetAPIByService<IClassApi>();
            cbbClass.DataSource = classApi.SearchAsync().GetAwaiter().GetResult().Items.Select(x => new CBBItem { Text = x.Name, Value =x.Id}).ToList();
      
        }

        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbClass.Items.Count > 0)
            {
                dt.Rows.Clear();
                dt.Columns.Clear();
                var students = studentApi.GetByClassIdAsync((cbbClass.SelectedItem as CBBItem).Value)
                                             .GetAwaiter()
                                             .GetResult()
                                             .ToList();
                dt.Columns.AddRange(new DataColumn[]
                  {
                            new DataColumn("Id", typeof(Guid)),
                            new DataColumn("Tên học sinh", typeof(string)),
                            new DataColumn("Ghi chú", typeof(string))

                  });
                foreach (var student in students)
                {
                    dt.Rows.Add(student.Id, student.UserLogin.Name, student.UserLogin.Note);
                }
                dgvStudentClass.DataSource = dt;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dgvStudentClass.SelectedRows.Count > 0)
            {
                var sts = new List<SessionRegisterSimple>();
                foreach(DataGridViewRow st in dgvStudentClass.SelectedRows)
                {
                    sts.Add(new SessionRegisterSimple
                    {
                       StudentId= Guid.Parse(st.Cells[0].Value.ToString()),
                       StudentName = st.Cells[1].Value.ToString(),
                       ClassId = (cbbClass.SelectedItem as CBBItem).Value, 
                       ClassName = (cbbClass.SelectedItem as CBBItem).Text
                    });
                }

                f(sts);
                this.Close();

            }
        }
    }
}
