using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.Courses
{
    public static class CourseEfCoreQueryableExtensions
    {
        public static IQueryable<Course> IncludeDetails(this IQueryable<Course> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Classes)
                .Include(x => x.LessonOfCourses)
                ;
        }
    }
}