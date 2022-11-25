using System;
using PBL4.LessonCompletes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.LessonCompletes
{
    public class LessonCompleteAppService : CrudAppService<LessonComplete, LessonCompleteDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateLessonCompleteDto, CreateUpdateLessonCompleteDto>, ILessonCompleteAppService
    {
        private readonly ILessonCompleteRepository _lessonCompleteRepository;
        public LessonCompleteAppService(ILessonCompleteRepository lessonCompleteRepository) : base(lessonCompleteRepository)
        {
            _lessonCompleteRepository = lessonCompleteRepository;
        }
    }
}