using System;
using System.Collections.Generic;
using PBL4.SessionRegisters;
using PBL4.TeacherOfSessions;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.Sessions
{
    public class Session : FullAuditedAggregateRoot<Guid>
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public  string  Name { get; set; }

        public ICollection<SessionRegister> SessionRegisters { get; set; }

        public ICollection<TeacherOfSession> TeacherOfSessions { get; set; }

        public Session()
        {
            SessionRegisters = new HashSet<SessionRegister>();
            TeacherOfSessions = new HashSet<TeacherOfSession>();
        }
    }
}