using System;
using PBL4.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL4.Students
{
    public class StudentRepository : EfCoreRepository<PBL4DbContext, Student, Guid>, IStudentRepository
    {
        public StudentRepository(IDbContextProvider<PBL4DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}