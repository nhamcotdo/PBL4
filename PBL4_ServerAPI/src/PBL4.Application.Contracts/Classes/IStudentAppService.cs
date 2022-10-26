using System;
using PBL4.Classes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Classes
{
  public interface IClassAppService : ICrudAppService<ClassDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateClassDto, CreateUpdateClassDto>, IApplicationService
  {
    
  }
}