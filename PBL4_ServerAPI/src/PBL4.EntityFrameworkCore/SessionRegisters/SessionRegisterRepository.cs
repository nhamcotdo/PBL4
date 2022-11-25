using System;
using System.Linq;
using System.Threading.Tasks;
using PBL4.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL4.SessionRegisters
{
    public class SessionRegisterRepository : EfCoreRepository<PBL4DbContext, SessionRegister, Guid>, ISessionRegisterRepository
    {
        public SessionRegisterRepository(IDbContextProvider<PBL4DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<SessionRegister>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}