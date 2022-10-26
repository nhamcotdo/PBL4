using PBL4_Winform.Dto.Terms;
using Refit;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.SdkCommon.Terms
{
    interface ITermApi
    {
        [Get("/api/app/term/{id}")]
        Task<TermDto> GetAsync(Guid id);

        [Get("/api/app/term")]
        Task<PagedResultDto<TermDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        [Delete("/api/app/term/")]
        Task DeleteAsync(Guid id);
    }
}
