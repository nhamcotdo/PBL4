using System;
using Volo.Abp.Domain.Repositories;

namespace PBL4.Registers
{
    public interface IRegisterRepository : IRepository<Register,Guid>
    {
        
    }
}