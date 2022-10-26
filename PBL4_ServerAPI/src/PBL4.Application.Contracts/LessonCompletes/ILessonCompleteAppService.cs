using System;
using PBL4.LessonCompletes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.LessonCompletes
{
  public interface ILessonCompleteAppService : ICrudAppService<LessonCompleteDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateLessonCompleteDto, CreateUpdateLessonCompleteDto>, IApplicationService
  {
    
  }
}