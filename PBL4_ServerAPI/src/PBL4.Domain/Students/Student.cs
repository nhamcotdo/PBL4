using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PBL4.LessonCompletes;
using PBL4.Registers;
using PBL4.SessionRegisters;
using PBL4.UserLogins;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.Students
{
    /// <summary>
    /// Học sinh
    /// <para>Created: 28/09/2022</para>
    /// </summary>
    public class Student : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// Tên phụ huynh
        /// </summary>
        [MaxLength(40)]
        public string ParentName { get; set; }

        public Guid UserId { get; set; }

        public UserLogin UserLogin { get; set;}

        public ICollection<SessionRegister> SessionRegisters { get; set; }

        public ICollection<Register> Registers { get; set; }

        public ICollection<LessonComplete> LessonCompletes { get; set; }

        public Student()
        {
            Registers = new HashSet<Register>();
            SessionRegisters = new HashSet<SessionRegister>();
            LessonCompletes = new HashSet<LessonComplete>();
        }
    }
}