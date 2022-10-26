using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PBL4.LessonCompletes.Dtos;
using PBL4.Registers.Dtos;
using PBL4.SessionRegisters.Dtos;
using PBL4.UserLogins.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.Students.Dtos
{
    public class StudentDto : EntityDto<Guid>
    {
        [MaxLength(40)]
        public string ParentName { get; set; }

        public Guid UserId { get; set; }

        public UserLoginDto UserLogin { get; set; }

        public ICollection<SessionRegisterDto> SessionRegisters { get; set; }

        public ICollection<RegisterDto> Registers { get; set; }

        public ICollection<LessonCompleteDto> LessonCompletes { get; set; }
    }
}