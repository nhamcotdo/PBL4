using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.Classes
{
    public static class ClassEfCoreQueryableExtensions
    {
        public static IQueryable<Class> IncludeDetails(this IQueryable<Class> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Course)
                .Include(x => x.SessionRegisters)
                .Include(x => x.Registers)
                .Include(x => x.LessonCompletes)
                .Include(x => x.Term)
                ;
        }
    }
}