using System;
using Volo.Abp.Domain.Repositories;

namespace PBL4.SessionRegisters
{
    public interface ISessionRegisterRepository : IRepository<SessionRegister,Guid>
    {
        
    }
}