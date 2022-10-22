using System;
using Volo.Abp.Domain.Repositories;

namespace PBL4.Students
{
    public interface IStudentRepository : IRepository<Student,Guid>
    {
        
    }
}