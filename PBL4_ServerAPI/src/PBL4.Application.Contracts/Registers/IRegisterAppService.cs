using System;
using PBL4.Registers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Registers
{
  public interface IRegisterAppService : ICrudAppService<RegisterDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateRegisterDto, CreateUpdateRegisterDto>, IApplicationService
  {
    
  }
}