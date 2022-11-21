using PBL4_Winform.Dto.Classes;
using PBL4_Winform.Dto.Lessons;
using PBL4_Winform.Dto.Sessions;
using PBL4_Winform.Dto.Student;
using PBL4_Winform.Dto.Terms;
using System;

namespace PBL4_Winform.Dto.SessionRegisters
{
    public class SessionRegisterDto
    {
        public string Status { get; set; }

        public Guid StudentId { get; set; }

        public Guid SessionId { get; set; }

        public String StudentName { get; set; }

        public Guid ClassId { get; set; }

        public Guid? LessonId { get; set; }

        public string ClassName { get; set; }

        public string LessonName { get; set; }
    }
}
