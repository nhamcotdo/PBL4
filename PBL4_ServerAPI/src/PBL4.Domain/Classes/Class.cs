using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PBL4.Courses;
using PBL4.LessonCompletes;
using PBL4.Registers;
using PBL4.SessionRegisters;
using PBL4.Sessions;
using PBL4.Terms;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.Classes
{
    /// <summary>
    /// Lớp học
    /// <para>Author: Nhamcotdo</para>
    /// <para>Created: 28/09/2022</para>
    /// </summary>
    public class Class : FullAuditedAggregateRoot<Guid>
    {
        [MaxLength(40)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public float Fee { get; set; }

        public Guid CourseId { get; set; }

        public Guid TermId { get; set; }

        public Term Term { get; set; }

        public Course Course { get; set; }

        public ICollection<Register> Registers { get; set; }

        public ICollection<SessionRegister> SessionRegisters { get; set; }

        public ICollection<LessonComplete> LessonCompletes { get; set; }
        
        public Class()
        {
            Registers = new HashSet<Register>();
            SessionRegisters = new HashSet<SessionRegister>();
            LessonCompletes = new HashSet<LessonComplete>();
        }
    }
}