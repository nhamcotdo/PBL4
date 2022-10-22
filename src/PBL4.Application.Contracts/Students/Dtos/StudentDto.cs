using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PBL4.UserLogins.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.Students.Dtos
{
    /// <summary>
    /// Học sinh
    /// <para>Created: 28/09/2022</para>
    /// </summary>
    public class StudentDto : EntityDto<Guid>
    {
        [MaxLength(40)]
        public string ParentName { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }
        
        public string Address { get; set; }

        public string Note { get; set; }

        public Guid UserId { get; set; }

        public UserLoginDto UserLogin;

        // public ICollection<SessionRegister> SessionRegisters { get; set; }

        // public ICollection<Register> Registers { get; set; }

        // public ICollection<LessonComplete> LessonCompletes { get; set; }
    }
}