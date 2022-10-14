using System;
using System.Collections.Generic;
using PBL4.TeacherOfSessions;
using PBL4.UserLogins;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.Domain.Teachers
{
    public class Teacher : FullAuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }

        public UserLogin UserLogin { get; set; }

        public ICollection<TeacherOfSession> TeacherOfSessions { get; set; }

        public Teacher()
        {
            TeacherOfSessions = new HashSet<TeacherOfSession>();
        }
    }
}