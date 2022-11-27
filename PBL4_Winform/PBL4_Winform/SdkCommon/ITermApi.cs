using PBL4_Winform.Dto.Terms;
using Refit;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.SdkCommon.Terms
{
    interface ITermApi : IAuthorizeCommon
    {
        [Get("/api/app/term/{id}")]
        Task<TermDto> GetAsync(Guid id);

        [Get("/api/app/term")]
        Task<PagedResultDto<TermDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        [Delete("/api/app/term/{id}")]
        Task DeleteAsync(Guid id);

        [Post("/api/app/term/search")]
        Task<PagedResultDto<TermDto>> SearchAsync(string filter = "");

        [Post("/api/app/term/")]
        Task<TermDto> CreateAsync(CreateUpdateSessionDto input);

        [Put("/api/app/term/{id}")]
        Task<TermDto> UpdateAsync(Guid id, CreateUpdateSessionDto input);
    }
}
