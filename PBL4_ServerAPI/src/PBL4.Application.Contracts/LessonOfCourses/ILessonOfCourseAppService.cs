using System;
using PBL4.LessonOfCourses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.LessonOfCourses
{
  public interface ILessonOfCourseAppService : ICrudAppService<LessonOfCourseDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateLessonOfCourseDto, CreateUpdateLessonOfCourseDto>, IApplicationService
  {
    
  }
}