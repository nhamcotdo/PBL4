using PBL4_Winform.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL4_Winform.Dto.Students
{
    public class CreateUpdateStudentDto
    {
        public string ParentName { get; set; }

        public CreateUpdateUserLoginDto UserLogin { get; set; }
    }
}
