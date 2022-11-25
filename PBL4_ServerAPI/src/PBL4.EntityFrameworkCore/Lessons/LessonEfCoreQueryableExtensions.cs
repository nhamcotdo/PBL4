using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.Lessons
{
    public static class LessonEfCoreQueryableExtensions
    {
        public static IQueryable<Lesson> IncludeDetails(this IQueryable<Lesson> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.LessonCompletes)
                .Include(x => x.LessonOfCourses).ThenInclude(x => x.Course).ThenInclude(x => x.Classes)
                .Include(x => x.SessionRegisters)
                ;
        }
    }
}