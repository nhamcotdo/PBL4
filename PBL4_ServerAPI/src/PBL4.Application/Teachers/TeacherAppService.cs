using System;
using Microsoft.AspNetCore.Authorization;
using PBL4.Permissions;
using PBL4.Teachers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Teachers
{
    [Authorize]
    public class TeacherAppService : CrudAppService<Teacher, TeacherDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateTeacherDto, CreateUpdateTeacherDto>, ITeacherAppService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherAppService(ITeacherRepository teacherRepository) : base(teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
    }
}