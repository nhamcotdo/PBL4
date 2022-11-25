using System;
using Volo.Abp.Domain.Repositories;

namespace PBL4.TeacherOfSessions
{
    public interface ITeacherOfSessionRepository : IRepository<TeacherOfSession,Guid>
    {
        
    }
}