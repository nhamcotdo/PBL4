using System;
using Volo.Abp.Domain.Repositories;

namespace PBL4.Lessons
{
    public interface ILessonRepository : IRepository<Lesson,Guid>
    {
        
    }
}