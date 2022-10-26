using System;

namespace PBL4.SessionRegisters.Dtos
{
    public class CreateUpdateSessionRegisterDto
    {
        public string Status { get; set; }

        public Guid StudentId { get; set; }

        public Guid SessionId { get; set; }
    }
}