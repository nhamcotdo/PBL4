using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PBL4.Terms
{
    public static class TermEfCoreQueryableExtensions
    {
        public static IQueryable<Term> IncludeDetails(this IQueryable<Term> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Classes)
                ;
        }
    }
}