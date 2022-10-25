using System;
using Volo.Abp.Domain.Repositories;

namespace PBL4.UserLogins
{
    public interface IUserLoginRepository : IRepository<UserLogin,Guid>
    {
        
    }
}