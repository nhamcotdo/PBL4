using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.TeacherOfSessions
{
    public static class TeacherOfSessionEfCoreQueryableExtensions
    {
        public static IQueryable<TeacherOfSession> IncludeDetails(this IQueryable<TeacherOfSession> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Teacher)
                .Include(x => x.Session)
                ;
        }
    }
}