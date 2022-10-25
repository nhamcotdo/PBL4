using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.Students
{
    public static class StudentEfCoreQueryableExtensions
    {
        public static IQueryable<Student> IncludeDetails(this IQueryable<Student> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.UserLogin);
        }
    }
}