using System;
using PBL4.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL4.UserLogins
{
  public class UserLoginRepository : EfCoreRepository<PBL4DbContext, UserLogin, Guid>, IUserLoginRepository
  {
  public UserLoginRepository(IDbContextProvider<PBL4DbContext> dbContextProvider) : base(dbContextProvider)
  {
  }
  
  
  }
}