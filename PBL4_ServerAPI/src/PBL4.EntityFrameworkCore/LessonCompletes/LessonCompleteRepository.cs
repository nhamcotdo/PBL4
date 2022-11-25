using System;
using System.Linq;
using System.Threading.Tasks;
using PBL4.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL4.LessonCompletes
{
    public class LessonCompleteRepository : EfCoreRepository<PBL4DbContext, LessonComplete, Guid>, ILessonCompleteRepository
    {
        public LessonCompleteRepository(IDbContextProvider<PBL4DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public override async Task<IQueryable<LessonComplete>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}