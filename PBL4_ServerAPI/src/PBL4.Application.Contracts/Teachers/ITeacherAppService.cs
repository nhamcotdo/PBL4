using System;
using PBL4.Teachers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Teachers
{
  public interface ITeacherAppService : ICrudAppService<TeacherDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateTeacherDto, CreateUpdateTeacherDto>, IApplicationService
  {
    
  }
}