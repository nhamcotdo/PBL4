using PBL4_Winform.Dto.Courses;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.SdkCommon
{
    interface ICourseApi : IAuthorizeCommon
    {
        [Get("/api/app/course/{id}")]
        Task<CourseDto> GetAsync(Guid id);

        [Get("/api/app/course")]
        Task<PagedResultDto<CourseDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        [Post("/api/app/course/")]
        Task<CourseDto> CreateAsync(CreateUpdateCourseDto input);

        [Put("/api/app/course/{id}")]
        Task<CourseDto> UpdateAsync(Guid id, CreateUpdateCourseDto input);

        [Delete("/api/app/course/{id}")]
        Task DeleteAsync(Guid id);

        [Post("/api/app/course/search")]
        Task<PagedResultDto<CourseDto>> SearchAsync(string filter = "");
    }
}
