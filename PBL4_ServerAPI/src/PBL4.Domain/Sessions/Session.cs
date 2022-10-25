using System;
using System.Collections.Generic;
using PBL4.Classes;
using PBL4.LessonCompletes;
using PBL4.Lessons;
using PBL4.SessionRegisters;
using PBL4.TeacherOfSessions;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.Sessions
{
    public class Session : FullAuditedAggregateRoot<Guid>
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid ClassId { get; set; }

        public Guid LessonId { get; set; }

        public Class Class { get; set; }

        public Lesson Lesson { get; set; }

        public ICollection<SessionRegister> SessionRegisters { get; set; }

        public ICollection<LessonComplete> LessonCompletes { get; set; }

        public ICollection<TeacherOfSession> TeacherOfSessions { get; set; }

        public Session()
        {
            SessionRegisters = new HashSet<SessionRegister>();
            LessonCompletes = new HashSet<LessonComplete>();
            TeacherOfSessions = new HashSet<TeacherOfSession>();
        }
    }
}