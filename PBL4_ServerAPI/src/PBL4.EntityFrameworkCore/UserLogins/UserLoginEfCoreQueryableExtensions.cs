using System.Linq;

namespace PBL4.UserLogins
{
    public static class UserLoginEfCoreQueryableExtensions
    {
        public static IQueryable<UserLogin> IncludeDetails(this IQueryable<UserLogin> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}