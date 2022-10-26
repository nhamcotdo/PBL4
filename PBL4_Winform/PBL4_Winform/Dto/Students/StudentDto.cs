using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL4_Winform.Dto.Student
{
    class StudentDto
    {
        public string ParentName { get; set; }

        //public string Name { get; set; }

        //public DateTime BirthDate { get; set; }

        //public string PhoneNumber { get; set; }

        //public string Address { get; set; }

        //public string Note { get; set; }

        public Guid UserId { get; set; }

        public UserLoginDto UserLogin;

        //public List<SessionRegisterDto> SessionRegisters { get; set; }

        //public List<RegisterDto> Registers { get; set; }

        //public List<LessonCompleteDto> LessonCompletes { get; set; }
    }
}
