using PBL4_Winform.Dto.SessionRegisters;
using System;
using System.Collections.Generic;

namespace PBL4_Winform.Dto.Sessions
{
    public class CreateUpdateSessionDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<CreateUpdateSessionRegisterDto> SessionRegisters { get; set; }
    }
}
