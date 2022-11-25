using PBL4_Winform.Dto.Classes;
using PBL4_Winform.Dto.Lessons;
using PBL4_Winform.Dto.Sessions;
using PBL4_Winform.Dto.Student;
using System;

namespace PBL4_Winform.Dto.SessionRegisters
{
    public class CreateUpdateSessionRegisterDto
    {
        public string Status { get; set; }

        public Guid StudentId { get; set; }

        public Guid SessionId { get; set; }

        public Guid ClassId { get; set; }

        public Guid? LessonId { get; set; }
    }
}
