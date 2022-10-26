using System;
using PBL4.Lessons.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Lessons
{
    public class LessonAppService : CrudAppService<Lesson, LessonDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateLessonDto, CreateUpdateLessonDto>, ILessonAppService
    {
        private readonly ILessonRepository _lessonRepository;
        public LessonAppService(ILessonRepository lessonRepository) : base(lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
    }
}