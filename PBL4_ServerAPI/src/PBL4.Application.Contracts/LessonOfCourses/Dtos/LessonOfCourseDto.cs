using System;
using PBL4.Courses.Dtos;
using PBL4.Lessons.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.LessonOfCourses.Dtos
{
    public class LessonOfCourseDto : EntityDto<Guid>
    {
         public Guid CourseId { get; set; }

        public Guid LessonId { get; set; }

        public LessonDto Lesson { get; set; }
    }
}