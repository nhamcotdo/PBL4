using PBL4_Winform.Dto.LessonCompletes;
using PBL4_Winform.Dto.Lessons;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.SdkCommon
{
    interface ILessonApi
    {
        [Get("/api/app/lesson/{id}")]
        Task<LessonDto> GetAsync(Guid id);

        [Get("/api/app/lesson")]
        Task<PagedResultDto<LessonDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        [Get("/api/app/lesson/lesson-by-class-id")]
        Task<List<LessonCompleteDto>> GetLessonByClassId(Guid lessonId, Guid classId);

        [Post("/api/app/lesson/")]
        Task<LessonDto> CreateAsync(CreateUpdateLessonDto input);

        [Put("/api/app/lesson/{id}")]
        Task <LessonDto> UpdateAsync(Guid id, CreateUpdateLessonDto input);

        [Delete("/api/app/lesson/{id}")]
        Task DeleteAsync(Guid id);

        [Post("/api/app/lesson/search")]
        Task<PagedResultDto<LessonDto>> SearchAsync(string filter = "");
    }
}
