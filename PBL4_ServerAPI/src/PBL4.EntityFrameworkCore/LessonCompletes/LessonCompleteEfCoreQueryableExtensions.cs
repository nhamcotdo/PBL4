using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.LessonCompletes
{
    public static class LessonCompleteEfCoreQueryableExtensions
    {
        public static IQueryable<LessonComplete> IncludeDetails(this IQueryable<LessonComplete> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Student)
                .Include(x => x.Class)
                .Include(x => x.Session)
                .Include(x => x.Lesson)
                ;
        }
    }
}