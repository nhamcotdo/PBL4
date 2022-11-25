using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;
using PBL4.Courses.Dtos;
using PBL4.Sessions.Dtos;
using PBL4.LessonCompletes.Dtos;
using PBL4.Registers.Dtos;
using PBL4.Terms.Dtos;

namespace PBL4.Classes.Dtos
{
    public class ClassDto : EntityDto<Guid>
    {
        [MaxLength(40)]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public float Fee { get; set; }

        public Guid CourseId { get; set; }

        public Guid TermId { get; set; }

        public TermDto Term { get; set; }

        public CourseDto Course { get; set; }

        // public IList<RegisterDto> Registers { get; set; }

        // public IList<SessionDto> Sessions { get; set; }

        // public IList<LessonCompleteDto> LessonCompletes { get; set; }
    }
}