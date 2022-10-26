using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.LessonOfCourses
{
    public static class LessonOfCourseEfCoreQueryableExtensions
    {
        public static IQueryable<LessonOfCourse> IncludeDetails(this IQueryable<LessonOfCourse> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Course)
                .Include(x => x.Lesson)
                ;
        }
    }
}