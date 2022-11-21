using PBL4_Winform.Dto.SessionRegisters;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.Dto.Sessions
{
    public class SessionDto : EntityDto<Guid>
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Name { get; set; }

        public int NumberStudent { get; set; }

        public int RealNumberStudent { get; set; }

        public List<SessionRegisterDto> SessionRegisters { get; set; }
    }
}
