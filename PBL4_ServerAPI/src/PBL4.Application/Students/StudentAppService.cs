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
using PBL4.UserLogins;
using PBL4.UserLogins.Dtos;
using PBL4.Lessons.Dtos;
using PBL4.Shared;
using PBL4.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace PBL4.Students
{
    [Authorize]
    public class StudentAppService : CrudAppService<Student, StudentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateStudentDto, CreateUpdateStudentDto>, IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRegisterRepository _registerRepository;
        private readonly ILessonCompleteRepository _lessonCompleteRepository;
        private readonly IUserLoginRepository _userLoginRepository;

        public StudentAppService(
                                IStudentRepository studentRepository,
                                IRegisterRepository registerRepository,
                                ILessonCompleteRepository lessonCompleteRepository,
                                IUserLoginRepository userLoginRepository
                                ) : base(studentRepository)
        {
            GetPolicyName = PBL4Permissions.View;
            GetListPolicyName = PBL4Permissions.View;
            CreatePolicyName = PBL4Permissions.Create;
            UpdatePolicyName = PBL4Permissions.Update;
            DeletePolicyName = PBL4Permissions.Delete;

            _studentRepository = studentRepository;
            _registerRepository = registerRepository;
            _lessonCompleteRepository = lessonCompleteRepository;
            _userLoginRepository = userLoginRepository;
        }

        [AllowAnonymous]
        public async Task<PagedResultDto<StudentDto>> SearchAsync(string filter = "")
        {
            var queryable = (await _studentRepository.GetQueryableAsync()).Include(x => x.UserLogin)
                .WhereIf(
                    !filter.IsNullOrEmpty(),
                    x =>
                    x.ParentName.Contains(filter)
                    || x.UserLogin.Name.Contains(filter)
                    || x.UserLogin.PhoneNumber.Contains(filter)
                    || x.UserLogin.UserName.Contains(filter)
                    || x.UserLogin.Address.Contains(filter)
                );
            var students = await queryable.ToListAsync();
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

        [AllowAnonymous]
        public async Task<List<LessonCompleteDto>> GetLessonByClassId(Guid studentId, Guid classId)
        {
            var lessonCompleteQueryable = await _lessonCompleteRepository.GetQueryableAsync();
            var lessonCompletes = await lessonCompleteQueryable
                                            .Where(x => x.StudentId == studentId && x.ClassId == classId)
                                            .Include(x => x.Lesson)
                                            .Include(x => x.SessionRegister)
                                            .ToListAsync()
                                            ;
            return ObjectMapper.Map<List<LessonComplete>, List<LessonCompleteDto>>(lessonCompletes);
        }

        [Authorize(PBL4Permissions.Create)]
        public override async Task<StudentDto> CreateAsync(CreateUpdateStudentDto input)
        {
            var userLogin = ObjectMapper.Map<CreateUpdateUserLoginDto, UserLogin>(input.UserLogin);
            var student = ObjectMapper.Map<CreateUpdateStudentDto, Student>(input);

            student.UserLogin = userLogin;

            return ObjectMapper.Map<Student, StudentDto>(await _studentRepository.InsertAsync(student, autoSave: true));
        }

        [Authorize(PBL4Permissions.Update)]
        public override Task<StudentDto> UpdateAsync(Guid id, CreateUpdateStudentDto input)
        {
            return base.UpdateAsync(id, input);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        [AllowAnonymous]
        public async Task<List<StudentDto>> GetByClassIdAsync(Guid classId)
        {

            return ObjectMapper.Map<List<Student>, List<StudentDto>>(await (await _registerRepository.WithDetailsAsync())
                                                                                                .Where(x => x.ClassId == classId && x.Status == CommonEnum.RegisterStatus.CONFIRMED.ToString())
                                                                                                .Select(x => x.Student)
                                                                                                .ToListAsync());
        }
    }
}