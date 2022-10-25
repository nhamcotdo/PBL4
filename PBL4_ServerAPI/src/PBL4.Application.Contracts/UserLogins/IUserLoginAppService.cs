using System;
using PBL4.UserLogins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.UserLogins
{
  public interface IUserLoginAppService : ICrudAppService<UserLoginDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateUserLoginDto, CreateUpdateUserLoginDto>, IApplicationService
  {
    
  }
}