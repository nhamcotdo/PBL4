using PBL4_Winform.Dto.LessonCompletes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL4_Winform.Dto.Lessons
{
    public class LessonDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string DocumentUrl { get; set; }

        public float TimePerLesson { get; set; }

        public string Guide { get; set; }

        //public IList<SessionDto> Sessions { get; set; }

        //public IList<LessonOfCourseDto> LessonOfCourses { get; set; }

        public IList<LessonCompleteDto> LessonCompletes { get; set; }
    }
}
