using System;
using PBL4.Sessions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Sessions
{
  public interface ISessionAppService : ICrudAppService<SessionDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSessionDto, CreateUpdateSessionDto>, IApplicationService
  {
    
  }
}