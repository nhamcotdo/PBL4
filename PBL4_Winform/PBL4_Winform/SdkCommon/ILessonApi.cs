using PBL4_Winform.Dto.LessonCompletes;
using PBL4_Winform.Dto.Lessons;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.SdkCommon
{
    interface ILessonApi : IAuthorizeCommon
    {
        [Get("/api/app/lesson/{id}")]
        Task<LessonDto> GetAsync(Guid id);

        [Get("/api/app/lesson")]
        Task<PagedResultDto<LessonDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        [Post("/api/app/lesson/")]
        Task<LessonDto> CreateAsync(CreateUpdateLessonDto input);

        [Put("/api/app/lesson/{id}")]
        Task <LessonDto> UpdateAsync(Guid id, CreateUpdateLessonDto input);

        [Delete("/api/app/lesson/{id}")]
        Task DeleteAsync(Guid id);

        [Post("/api/app/lesson/search")]
        Task<PagedResultDto<LessonDto>> SearchAsync(string filter = "");

        [Get("/api/app/lesson/by-student-id-and-class-id")]
        Task<List<LessonDto>> GetListByStudentIdAndClassId(Guid classId, Guid studentId);
    }
}
