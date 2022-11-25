using System;
using System.Collections.Generic;
using PBL4.LessonCompletes.Dtos;
using PBL4.LessonOfCourses.Dtos;
using PBL4.Sessions.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.Lessons.Dtos
{
    public class LessonDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        
        public string DocumentUrl { get; set; }
        
        public float TimePerLesson { get; set; }
        
        public string Guide { get; set; }
    }
}