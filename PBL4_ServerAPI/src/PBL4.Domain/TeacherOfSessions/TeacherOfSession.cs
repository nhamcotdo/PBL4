using System;
using PBL4.Sessions;
using PBL4.Teachers;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.TeacherOfSessions
{
    public class TeacherOfSession :  FullAuditedAggregateRoot<Guid>
    {
        public Guid TeacherId { get; set; }

        public Guid SessionId { get; set; }

        public Teacher Teacher { get; set; }

        public Session Session { get; set; }
    }
}