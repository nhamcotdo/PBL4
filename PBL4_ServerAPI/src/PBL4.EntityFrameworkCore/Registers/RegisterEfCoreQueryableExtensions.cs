using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.Registers
{
    public static class RegisterEfCoreQueryableExtensions
    {
        public static IQueryable<Register> IncludeDetails(this IQueryable<Register> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Class)
                .Include(x => x.Student)
                .ThenInclude(x => x.UserLogin)
                ;
        }
    }
}