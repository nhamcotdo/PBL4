using System;
using PBL4.Classes.Dtos;
using PBL4.Lessons.Dtos;
using PBL4.Sessions.Dtos;
using PBL4.Students.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.LessonCompletes.Dtos
{
    public class LessonCompleteDto : EntityDto<Guid>
    {
        public Guid StudentId { get; set; }

        public Guid LessonId { get; set; }

        public Guid ClassId { get; set; }

        public Guid SessionId { get; set; }

        public String Comment { get; set; }

        public bool IsComplete { get; set; }

        public StudentDto Student { get; set; }

        public LessonDto Lesson { get; set; }

        public ClassDto Class { get; set; }

        public SessionDto Session { get; set; }
    }
}