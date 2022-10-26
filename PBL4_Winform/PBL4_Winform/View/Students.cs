using PBL4_Winform.ConfigManagers;
using PBL4_Winform.SdkCommon;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.View
{
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
            var frmLogin = new LoginForm();
            frmLogin.ShowDialog();
            var apiStudent = ConfigManager.GetAPIByService<IStudentApi>();
            var studentDtos = apiStudent.GetListAsync(new PagedAndSortedResultRequestDto())
                                                 .GetAwaiter()
                                                 .GetResult()
                                                 ;
            var studentDto = apiStudent.GetAsync(System.Guid.Parse("54ED7699-FB95-089C-D0E6-3A072138CBEC")).GetAwaiter().GetResult();
            //dataGridView1.DataSource = studentDtos.Items.Select(x => new
            //{
            //    Id = x.UserId,
            //    Name = x.UserLogin.Name,
            //    ParentName = x.ParentName,
            //    BirthDate = x.UserLogin.BirthDate,
            //    PhoneNumber = x.UserLogin.PhoneNumber,
            //    Address = x.UserLogin.Address,
            //    Note = x.UserLogin.Note
            //}).ToList();

            List<object> l = new List<object>();

            foreach(var x in studentDtos.Items)
            {
                l.Add(new
                {
                    Id = x.UserId,
                    Name = x.UserLogin.Name,
                    ParentName = x.ParentName,
                    BirthDate = x.UserLogin.BirthDate,
                    PhoneNumber = x.UserLogin.PhoneNumber,
                    Address = x.UserLogin.Address,
                    Note = x.UserLogin.Note
                });
            }
            dataGridView1.DataSource = l;

        }
    }
}
