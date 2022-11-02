using PBL4_Winform.Dto.LessonCompletes;
using PBL4_Winform.Dto.Registers;
using System;
using System.Collections.Generic;

namespace PBL4_Winform.Dto.Student
{
    public class StudentDto
    {
        public Guid Id { get; set; }

        public string ParentName { get; set; }

        public Guid UserId { get; set; }


        public UserLoginDto UserLogin;

        //public List<SessionRegisterDto> SessionRegisters { get; set; }

        public List<RegisterDto> Registers { get; set; }

        public List<LessonCompleteDto> LessonCompletes { get; set; }
    }
}
