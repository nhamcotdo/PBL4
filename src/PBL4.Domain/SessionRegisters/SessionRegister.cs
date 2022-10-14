using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBL4.Sessions;
using PBL4.Students;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.SessionRegisters
{
    public class SessionRegister : FullAuditedAggregateRoot<Guid>
    {
        public string Status { get; set; }

        public Guid StudentId { get; set; }
        
        public Guid SessionId { get; set; }

        public Student Student { get; set; }

        public Session Session { get; set; }
    }
}