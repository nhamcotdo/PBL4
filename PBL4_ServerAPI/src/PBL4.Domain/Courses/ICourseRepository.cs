using System;
using Volo.Abp.Domain.Repositories;

namespace PBL4.Courses
{
    public interface ICourseRepository : IRepository<Course,Guid>
    {
        
    }
}