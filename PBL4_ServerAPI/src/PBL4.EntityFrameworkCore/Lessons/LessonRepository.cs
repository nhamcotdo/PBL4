using System;
using System.Linq;
using System.Threading.Tasks;
using PBL4.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL4.Lessons
{
    public class LessonRepository : EfCoreRepository<PBL4DbContext, Lesson, Guid>, ILessonRepository
    {
        public LessonRepository(IDbContextProvider<PBL4DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Lesson>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}