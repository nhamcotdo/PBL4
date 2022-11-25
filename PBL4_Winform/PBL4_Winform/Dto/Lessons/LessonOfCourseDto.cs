using System;

namespace PBL4_Winform.Dto.Lessons
{
    public class LessonOfCourseDto
    {
        public Guid CourseId { get; set; }

        public Guid LessonId { get; set; }

        public LessonDto Lesson { get; set; }
    }
}
