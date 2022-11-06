using System.Collections.Generic;
using PBL4.LessonOfCourses.Dtos;

namespace PBL4.Courses.Dtos
{
    public class CreateUpdateCourseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfLesson { get; set; }
        
        public IList<LessonOfCourseDto> LessonOfCourses  { get; set; }
    }
}