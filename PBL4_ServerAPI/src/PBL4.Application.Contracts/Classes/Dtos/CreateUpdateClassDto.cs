using System;
using System.ComponentModel.DataAnnotations;

namespace PBL4.Classes.Dtos
{
    public class CreateUpdateClassDto
    {
        [MaxLength(40)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public float Fee { get; set; }

        public Guid CourseId { get; set; }

        public Guid TermId { get; set; }
    }
}