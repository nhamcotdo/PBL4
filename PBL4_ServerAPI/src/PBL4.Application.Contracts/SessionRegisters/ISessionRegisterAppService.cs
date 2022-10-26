using System;
using PBL4.SessionRegisters.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.SessionRegisters
{
  public interface ISessionRegisterAppService : ICrudAppService<SessionRegisterDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSessionRegisterDto, CreateUpdateSessionRegisterDto>, IApplicationService
  {
    
  }
}