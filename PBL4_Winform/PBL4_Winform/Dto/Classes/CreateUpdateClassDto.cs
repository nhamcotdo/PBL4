using PBL4_Winform.Dto.Courses;
using PBL4_Winform.Dto.Terms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL4_Winform.Dto.Classes
{
    public class CreateUpdateClassDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public float Fee { get; set; }

        public Guid CourseId { get; set; }

        public Guid TermId { get; set; }

        public TermDto Term { get; set; }

        public CourseDto Course { get; set; }
    }
}
