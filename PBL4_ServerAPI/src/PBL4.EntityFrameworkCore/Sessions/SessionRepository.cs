using System;
using System.Linq;
using System.Threading.Tasks;
using PBL4.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL4.Sessions
{
    public class SessionRepository : EfCoreRepository<PBL4DbContext, Session, Guid>, ISessionRepository
    {
        public SessionRepository(IDbContextProvider<PBL4DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        
        public override async Task<IQueryable<Session>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}