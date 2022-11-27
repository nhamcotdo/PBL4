using PBL4_Winform.Dto.LessonCompletes;
using PBL4_Winform.Dto.Student;
using PBL4_Winform.Dto.Students;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.SdkCommon
{
    interface IStudentApi : IAuthorizeCommon
    {
        [Get("/api/app/student/{id}")]
        Task<StudentDto> GetAsync(Guid id);


        [Get("/api/app/student")]
        Task<PagedResultDto<StudentDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        [Get("/api/app/student/lesson-by-class-id")]
        Task<List<LessonCompleteDto>> GetLessonByClassId(Guid studentId, Guid classId);

        [Post("/api/app/student/")]
        Task<StudentDto> CreateAsync(CreateUpdateStudentDto input);

        [Put("/api/app/student/{id}")]
        Task <StudentDto> UpdateAsync(Guid id, CreateUpdateStudentDto input);

        [Delete("/api/app/student/{id}")]
        Task DeleteAsync(Guid id);

        [Post("/api/app/student/search")]
        Task<PagedResultDto<StudentDto>> SearchAsync(string filter = "");

        [Get("/api/app/student/by-class-id/{classId}")]
        Task<List<StudentDto>> GetByClassIdAsync(Guid classId);
    }
}
