using PBL4_Winform.Dto.LessonCompletes;
using System;

namespace PBL4_Winform.Dto.Lessons
{
    public class LessonView
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string DocumentUrl { get; set; }

        public float TimePerLesson { get; set; }
    }
}
