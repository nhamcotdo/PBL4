using System;
using PBL4.Sessions.Dtos;
using PBL4.Students.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.SessionRegisters.Dtos
{
    public class SessionRegisterDto : EntityDto<Guid>
    {
        public string Status { get; set; }

        public Guid StudentId { get; set; }
        
        public Guid SessionId { get; set; }

        public StudentDto Student { get; set; }

        public SessionDto Session { get; set; }
    }
}