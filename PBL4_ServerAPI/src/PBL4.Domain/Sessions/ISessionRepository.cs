using System;
using Volo.Abp.Domain.Repositories;

namespace PBL4.Sessions
{
    public interface ISessionRepository : IRepository<Session,Guid>
    {
        
    }
}