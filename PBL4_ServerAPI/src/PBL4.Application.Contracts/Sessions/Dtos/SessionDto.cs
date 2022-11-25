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

        public string Name { get; set; }

        public int NumberStudent { get; set; }

        public int RealNumberStudent { get; set; }

        public List<SessionRegisterDto> SessionRegisters { get; set; }
    }
}