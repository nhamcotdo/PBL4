using System.Collections.Generic;
using PBL4.Sessions.Dtos;

namespace PBL4.Lessons.Dtos
{
    public class CreateUpdateLessonDto
    {
        public string Title { get; set; }

        public string DocumentUrl { get; set; }

        public float TimePerLesson { get; set; }

        public string Guide { get; set; }
    }
}