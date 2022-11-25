using System;
using System.Linq;
using System.Threading.Tasks;
using PBL4.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL4.LessonOfCourses
{
    public class LessonOfCourseRepository : EfCoreRepository<PBL4DbContext, LessonOfCourse, Guid>, ILessonOfCourseRepository
    {
        public LessonOfCourseRepository(IDbContextProvider<PBL4DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public override async Task<IQueryable<LessonOfCourse>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}