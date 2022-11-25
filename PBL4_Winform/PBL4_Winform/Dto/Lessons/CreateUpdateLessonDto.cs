using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL4_Winform.Dto.Lessons
{
    internal class CreateUpdateLessonDto
    {
        public string Title { get; set; }

        public string DocumentUrl { get; set; }

        public float TimePerLesson { get; set; }

        public string Guide { get; set; }
    }
}
