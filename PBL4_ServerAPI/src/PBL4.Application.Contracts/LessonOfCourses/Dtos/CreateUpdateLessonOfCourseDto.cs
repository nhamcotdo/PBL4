using System;
namespace PBL4.LessonOfCourses.Dtos
{
    public class CreateUpdateLessonOfCourseDto
    {
         public Guid CourseId { get; set; }

        public Guid LessonId { get; set; }
    }
}