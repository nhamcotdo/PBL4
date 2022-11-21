using System;
using System.Collections.Generic;
using PBL4.Classes;
using PBL4.LessonCompletes;
using PBL4.Lessons;
using PBL4.Sessions;
using PBL4.Students;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.SessionRegisters
{
    public class SessionRegister : FullAuditedAggregateRoot<Guid>
    {
        public string Status { get; set; }

        public Guid StudentId { get; set; }

        public Guid SessionId { get; set; }

        public Student Student { get; set; }

        public Session Session { get; set; }

        public Guid ClassId { get; set; }

        public Guid? LessonId { get; set; }

        public Class Class { get; set; }

        public Lesson Lesson { get; set; }
        
        public ICollection<LessonComplete> LessonCompletes { get; set; }

        public SessionRegister()
        {
            LessonCompletes = new HashSet<LessonComplete>();
        }
    }
}