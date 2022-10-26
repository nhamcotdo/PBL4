using System;
using PBL4.Sessions.Dtos;
using PBL4.Teachers.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.TeacherOfSessions.Dtos
{
    public class TeacherOfSessionDto : EntityDto<Guid>
    {
        public Guid TeacherId { get; set; }

        public Guid SessionId { get; set; }

        public TeacherDto Teacher { get; set; }

        public SessionDto Session { get; set; }
    }
}