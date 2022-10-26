using System;
using Volo.Abp.Domain.Repositories;

namespace PBL4.Teachers
{
    public interface ITeacherRepository : IRepository<Teacher,Guid>
    {
        
    }
}