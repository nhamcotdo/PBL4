using System;
using Microsoft.AspNetCore.Authorization;
using PBL4.Permissions;
using PBL4.TeacherOfSessions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.TeacherOfSessions
{
    [Authorize]
    public class TeacherOfSessionAppService : CrudAppService<TeacherOfSession, TeacherOfSessionDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateTeacherOfSessionDto, CreateUpdateTeacherOfSessionDto>, ITeacherOfSessionAppService
    {
        private readonly ITeacherOfSessionRepository _teacherOfSessionRepository;
        public TeacherOfSessionAppService(ITeacherOfSessionRepository teacherOfSessionRepository) : base(teacherOfSessionRepository)
        {
            _teacherOfSessionRepository = teacherOfSessionRepository;
        }
    }
}