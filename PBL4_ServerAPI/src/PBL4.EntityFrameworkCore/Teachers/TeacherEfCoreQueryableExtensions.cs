using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.Teachers
{
    public static class TeacherEfCoreQueryableExtensions
    {
        public static IQueryable<Teacher> IncludeDetails(this IQueryable<Teacher> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.UserLogin)
                .Include(x => x.TeacherOfSessions)
                ;
        }
    }
}