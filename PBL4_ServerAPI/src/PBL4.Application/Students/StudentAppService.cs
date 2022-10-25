using System;
using PBL4.Students.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Students
{
    public class StudentAppService : CrudAppService<Student, StudentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateStudentDto, CreateUpdateStudentDto>, IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentAppService(IStudentRepository studentRepository) : base(studentRepository)
        {
            _studentRepository = studentRepository;
        }
    }
}