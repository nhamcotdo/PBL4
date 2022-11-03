using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PBL4.Lessons.Dtos;
using Volo.Abp.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Services;
using System.Linq;

namespace PBL4.Lessons
{
    public class LessonAppService : CrudAppService<Lesson, LessonDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateLessonDto, CreateUpdateLessonDto>, ILessonAppService
    {
        private readonly ILessonRepository _lessonRepository;
        public LessonAppService(ILessonRepository lessonRepository) : base(lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<PagedResultDto<LessonDto>> SearchAsync(string filter = "")
        {
            var queryable = (await _lessonRepository.GetQueryableAsync())
                .WhereIf(
                    !filter.IsNullOrEmpty(),
                    x=>
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
    }
}