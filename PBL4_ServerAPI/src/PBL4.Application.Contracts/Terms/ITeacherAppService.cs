using System;
using PBL4.Terms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Terms
{
  public interface ITermAppService : ICrudAppService<TermDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateTermDto, CreateUpdateTermDto>, IApplicationService
  {
    
  }
}