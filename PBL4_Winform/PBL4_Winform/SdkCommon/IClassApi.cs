using PBL4_Winform.Dto.Classes;
using Refit;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.SdkCommon
{
    interface IClassApi
    {
        [Get("/api/app/class/{id}")]
        Task<ClassDto> GetAsync(Guid id);

        [Get("/api/app/class")]
        Task<PagedResultDto<ClassDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        [Post("/api/app/class/")]
        Task<ClassDto> CreateAsync(CreateUpdateClassDto input);

        [Put("/api/app/class/{id}")]
        Task <ClassDto> UpdateAsync(Guid id, CreateUpdateClassDto input);

        [Delete("/api/app/class/{id}")]
        Task DeleteAsync(Guid id);

        [Post("/api/app/class/search")]
        Task<PagedResultDto<ClassDto>> SearchAsync(string filter = "");
    }
}
