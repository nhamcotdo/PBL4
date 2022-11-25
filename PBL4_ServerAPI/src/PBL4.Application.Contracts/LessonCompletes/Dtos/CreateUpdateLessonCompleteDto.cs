using System;
using PBL4.Classes.Dtos;
using PBL4.Lessons.Dtos;
using PBL4.Sessions.Dtos;
using PBL4.Students.Dtos;

namespace PBL4.LessonCompletes.Dtos
{
    public class CreateUpdateLessonCompleteDto
    {
        public Guid StudentId { get; set; }

        public Guid LessonId { get; set; }

        public Guid ClassId { get; set; }

        public Guid? SessionId { get; set; }

        public String Comment { get; set; }

        public bool IsComplete { get; set; }
    }
}