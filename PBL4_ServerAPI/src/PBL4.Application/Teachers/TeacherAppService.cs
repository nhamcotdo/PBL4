using System;
using PBL4.Teachers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Teachers
{
    public class TeacherAppService : CrudAppService<Teacher, TeacherDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateTeacherDto, CreateUpdateTeacherDto>, ITeacherAppService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherAppService(ITeacherRepository teacherRepository) : base(teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
    }
}