using System;
using PBL4.Lessons.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Lessons
{
  public interface ILessonAppService : ICrudAppService<LessonDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateLessonDto, CreateUpdateLessonDto>, IApplicationService
  {
    
  }
}