using System;
using System.Linq;
using System.Threading.Tasks;
using PBL4.Students.Dtos;
using Volo.Abp.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Services;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using PBL4.Registers;
using PBL4.Registers.Dtos;
using PBL4.Classes;
using PBL4.Classes.Dtos;
using PBL4.LessonCompletes;
using PBL4.LessonCompletes.Dtos;
using PBL4.Lessons;
using PBL4.Lessons.Dtos;
using PBL4.Sessions.Dtos;
using PBL4.Sessions;

namespace PBL4.Students
{
    public class StudentAppService : CrudAppService<Student, StudentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateStudentDto, CreateUpdateStudentDto>, IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRegisterRepository _registerRepository;
        private readonly ILessonCompleteRepository _lessonCompleteRepository;

        public StudentAppService(
                                IStudentRepository studentRepository,
                                IRegisterRepository registerRepository,
                                ILessonCompleteRepository lessonCompleteRepository
                                ) : base(studentRepository)
        {
            _studentRepository = studentRepository;
            _registerRepository = registerRepository;
            _lessonCompleteRepository = lessonCompleteRepository;
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
            var rs = new PagedResultDto<StudentDto>(maxResultCount, ObjectMapper.Map<List<Student>, List<StudentDto>>(students));

            return rs;
        }

        public override async Task<StudentDto> GetAsync(Guid id)
        {
            var queryable = await _studentRepository.GetQueryableAsync();
            var student = await queryable.Include(x => x.UserLogin)
                                          .Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();
            var studentDto = ObjectMapper.Map<Student, StudentDto>(student);

            studentDto.Registers = await _registerRepository
                                                .Where(x => x.StudentId == id)
                                                .Include(x => x.Class)
                                                .Select(x => new RegisterDto
                                                {
                                                    Id = x.Id,
                                                    Class = ObjectMapper.Map<Class, ClassDto>(x.Class),
                                                    Status = x.Status,
                                                    Discount = x.Discount,
                                                    Price = x.Price,
                                                    ClassId = x.ClassId,
                                                })
                                                .ToListAsync(); ;

            return studentDto;
        }

        public async Task<List<LessonCompleteDto>> GetLessonByClassId(Guid studentId, Guid classId)
        {
            var lessonCompleteQueryable = await _lessonCompleteRepository.GetQueryableAsync();
            var lessonCompletes = await lessonCompleteQueryable
                                            .Where(x => x.StudentId == studentId && x.ClassId == classId)
                                            .Include(x => x.Lesson)
                                            .Include(x => x.Session)
                                            .ToListAsync()
                                            ;
            return ObjectMapper.Map<List<LessonComplete>, List<LessonCompleteDto>>(lessonCompletes);
        }
    }
}