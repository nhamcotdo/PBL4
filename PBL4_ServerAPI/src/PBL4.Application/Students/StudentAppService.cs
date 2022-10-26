using System;
using System.Linq;
using System.Threading.Tasks;
using PBL4.Students.Dtos;
using Volo.Abp.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Services;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;

namespace PBL4.Students
{
    public class StudentAppService : CrudAppService<Student, StudentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateStudentDto, CreateUpdateStudentDto>, IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentAppService(IStudentRepository studentRepository) : base(studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public override async Task<PagedResultDto<StudentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _studentRepository.GetQueryableAsync();
            var students = await queryable
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .Include(x => x.UserLogin)
                .ToListAsync();
            var maxResultCount = await queryable.CountAsync();
            var rs =  new PagedResultDto<StudentDto>(maxResultCount ,ObjectMapper.Map<List<Student>,List<StudentDto>>(students));

            return rs;
        }

        public override async Task<StudentDto> GetAsync(Guid id)
        {
            var queryable = await _studentRepository.GetQueryableAsync();
            
            return ObjectMapper.Map<Student,StudentDto>(await queryable.Include(x => x.UserLogin).Where(x => x.Id == id).FirstOrDefaultAsync());
        }
        
    }
}