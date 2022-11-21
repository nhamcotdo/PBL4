using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.Sessions
{
    public static class SessionEfCoreQueryableExtensions
    {
        public static IQueryable<Session> IncludeDetails(this IQueryable<Session> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.SessionRegisters).ThenInclude(x => x.Student).ThenInclude(x => x.UserLogin)
                .Include(x => x.SessionRegisters).ThenInclude(x => x.Class)
                .Include(x => x.SessionRegisters).ThenInclude(x => x.Lesson)
                .Include(x => x.TeacherOfSessions)
                ;
        }
    }
}