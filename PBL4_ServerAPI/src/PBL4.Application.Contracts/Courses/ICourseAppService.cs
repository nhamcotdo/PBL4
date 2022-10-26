using System;
using PBL4.Courses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Courses
{
  public interface ICourseAppService : ICrudAppService<CourseDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCourseDto, CreateUpdateCourseDto>, IApplicationService
  {
    
  }
}