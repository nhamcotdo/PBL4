using System;
using PBL4.Classes.Dtos;
using PBL4.Lessons.Dtos;

namespace PBL4.Sessions.Dtos
{
    public class CreateUpdateSessionDto
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid ClassId { get; set; }

        public Guid LessonId { get; set; }
    }
}