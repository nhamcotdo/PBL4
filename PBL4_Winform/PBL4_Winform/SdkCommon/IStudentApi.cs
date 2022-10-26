using PBL4_Winform.Dto.Student;
using Refit;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.SdkCommon
{
    interface IStudentApi
    {
        [Get("/api/app/student/{id}")]
        Task<StudentDto> GetAsync(Guid id);


        [Get("/api/app/student")]
        Task<PagedResultDto<StudentDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
