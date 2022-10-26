using System;
using System.Collections.Generic;
using PBL4.Classes.Dtos;
using PBL4.LessonCompletes.Dtos;
using PBL4.Lessons.Dtos;
using PBL4.SessionRegisters.Dtos;
using PBL4.TeacherOfSessions.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.Sessions.Dtos
{
    public class SessionDto : EntityDto<Guid>
    {
       public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid ClassId { get; set; }

        public Guid LessonId { get; set; }

        public ClassDto Class { get; set; }

        public LessonDto Lesson { get; set; }

        public IList<SessionRegisterDto> SessionRegisters { get; set; }

        public IList<LessonCompleteDto> LessonCompletes { get; set; }

        public IList<TeacherOfSessionDto> TeacherOfSessions { get; set; }

    }
}