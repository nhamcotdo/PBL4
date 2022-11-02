using PBL4_Winform.ConfigManagers;
using PBL4_Winform.SdkCommon;
using PBL4_Winform.View.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.View
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
            //var frmLogin = new LoginForm();
            //frmLogin.ShowDialog();
            var apiStudent = ConfigManager.GetAPIByService<IStudentApi>();
            var studentDtos = apiStudent.GetListAsync(new PagedAndSortedResultRequestDto())
                                                 .GetAwaiter()
                                                 .GetResult()
                                                 ;
            dataGridView1.DataSource = studentDtos.Items.Select(x => new
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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Guid id = (Guid)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            (new StudentDetail(id)).Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Guid id = (Guid)dataGridView1.SelectedRows[0].Cells[0].Value;
                (new StudentDetail(id, true)).Show();
            }
        }
    }
}
