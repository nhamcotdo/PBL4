using PBL4_Winform.Dto.Courses;
using PBL4_Winform.Dto.Sessions;
using System;

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

        public SessionDto Term { get; set; }

        public CourseDto Course { get; set; }
    }
}
