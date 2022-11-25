using System;
using System.Linq;
using System.Threading.Tasks;
using PBL4.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL4.TeacherOfSessions
{
    public class TeacherOfSessionRepository : EfCoreRepository<PBL4DbContext, TeacherOfSession, Guid>, ITeacherOfSessionRepository
    {
        public TeacherOfSessionRepository(IDbContextProvider<PBL4DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public override async Task<IQueryable<TeacherOfSession>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}