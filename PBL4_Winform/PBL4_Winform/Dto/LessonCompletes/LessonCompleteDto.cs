using PBL4_Winform.Dto.Courses;
using PBL4_Winform.Dto.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL4_Winform.Dto.LessonCompletes
{
    public class LessonCompleteDto
    {
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }

        public bool IsComplete { get; set; }

        public string Comment { get; set; }

        public Guid LessonId { get; set; }

        public CourseDto Course { get; set; }

        public LessonDto Lesson { get; set; }
    }
}
