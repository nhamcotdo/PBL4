using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.SessionRegisters
{
    public static class SessionRegisterEfCoreQueryableExtensions
    {
        public static IQueryable<SessionRegister> IncludeDetails(this IQueryable<SessionRegister> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Student)
                .Include(x => x.Session)
                ;
        }
    }
}