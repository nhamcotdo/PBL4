using System;
using System.Collections.Generic;
using PBL4.TeacherOfSessions.Dtos;
using PBL4.UserLogins.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.Teachers.Dtos
{
    public class TeacherDto : EntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public UserLoginDto UserLogin { get; set; }
        
        public IList<TeacherOfSessionDto> TeacherOfSessions { get; set; }
    }
}