using PBL4_Winform.Dto.Sessions;
using Refit;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.SdkCommon.Sessions

{
    interface ISessionApi : IAuthorizeCommon
    {
        [Get("/api/app/session/{id}")]
        Task<SessionDto> GetAsync(Guid id);

        [Get("/api/app/session")]
        Task<PagedResultDto<SessionDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        [Delete("/api/app/session/{id}")]
        Task DeleteAsync(Guid id);

        [Post("/api/app/session/search")]
        Task<PagedResultDto<SessionDto>> SearchAsync(string filter = "");

        [Post("/api/app/session/session")]
        Task CreateSessionAsync(CreateUpdateSessionDto input);

        [Put("/api/app/session/{id}")]
        Task<SessionDto> UpdateAsync(Guid id, CreateUpdateSessionDto input);
    }
}
