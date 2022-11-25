using System;
using PBL4.TeacherOfSessions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.TeacherOfSessions
{
  public interface ITeacherOfSessionAppService : ICrudAppService<TeacherOfSessionDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateTeacherOfSessionDto, CreateUpdateTeacherOfSessionDto>, IApplicationService
  {
    
  }
}