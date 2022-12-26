using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PBL4.Lessons.Dtos;
using Volo.Abp.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Services;
using System.Linq;
using PBL4.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace PBL4.Lessons
{
    [Authorize]
    public class LessonAppService : CrudAppService<Lesson, LessonDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateLessonDto, CreateUpdateLessonDto>, ILessonAppService
    {
        private readonly ILessonRepository _lessonRepository;
        public LessonAppService(ILessonRepository lessonRepository) : base(lessonRepository)
        {
            _lessonRepository = lessonRepository;
            GetPolicyName = PBL4Permissions.Lesson.Get;
            GetListPolicyName = PBL4Permissions.Lesson.Get;
            CreatePolicyName = PBL4Permissions.Lesson.Create;
            UpdatePolicyName = PBL4Permissions.Lesson.Update;
            DeletePolicyName = PBL4Permissions.Lesson.Delete;
        }

        [AllowAnonymous]
        public async Task<PagedResultDto<LessonDto>> SearchAsync(string filter = "")
        {
            var queryable = (await _lessonRepository.GetQueryableAsync())
                .WhereIf(
                    !filter.IsNullOrEmpty(),
                    x =>
                    x.Title.Contains(filter)
                    || x.DocumentUrl.Contains(filter)
                    || x.Guide.Contains(filter)
                    || x.TimePerLesson.ToString().Contains(filter)
                );
            var lessons = await queryable.ToListAsync();
            var maxResultCount = await queryable.CountAsync();
            var rs = new PagedResultDto<LessonDto>(maxResultCount, ObjectMapper.Map<List<Lesson>, List<LessonDto>>(lessons));

            return rs;
        }

        [Authorize(PBL4Permissions.Lesson.Get)]
        public async Task<List<LessonDto>> GetListByStudentIdAndClassId(Guid classId, Guid studentId)
        {
            var queryable = await _lessonRepository.WithDetailsAsync();

            return ObjectMapper.Map<List<Lesson>, List<LessonDto>>(queryable
                                                                    .Where(
                                                                        x => x.LessonOfCourses.Any(y => y.Course.Classes.Any(z => z.Id == classId)) &&
                                                                        x.LessonCompletes.Any(y => y.StudentId == studentId && !y.IsComplete))
                                                                    .ToList());
        }
    }
}