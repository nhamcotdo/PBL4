using System;
using Volo.Abp.Domain.Repositories;

namespace PBL4.LessonOfCourses
{
    public interface ILessonOfCourseRepository : IRepository<LessonOfCourse,Guid>
    {
        
    }
}