using System;
using System.Collections.Generic;
using PBL4.SessionRegisters.Dtos;

namespace PBL4.Sessions.Dtos
{
    public class CreateUpdateSessionDto 
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Name { get; set; }

        public List<CreateUpdateSessionRegisterDto> SessionRegisters { get; set; }
    }
}