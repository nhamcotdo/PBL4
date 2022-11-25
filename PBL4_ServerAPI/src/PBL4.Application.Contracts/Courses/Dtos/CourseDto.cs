using System;
using System.Collections.Generic;
using PBL4.Classes.Dtos;
using PBL4.LessonOfCourses.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.Courses.Dtos
{
    public class CourseDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfLesson { get; set; }
        // public IList<ClassDto> Classes { get; set; }
        public IList<LessonOfCourseDto> LessonOfCourses { get; set; }
    }
}