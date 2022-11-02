using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace PBL4_Winform.SdkCommon
{
    public interface IUsersApi : IAuthorizeCommon
    {
        [Get("/api/identity/users")]
        Task<PagedResultDto<IdentityUserDto>> GetListAsync(string Filter, PagedAndSortedResultRequestDto input);

        [Get("/api/identity/users/by-username/{userName}")]
        Task <IdentityUserDto> GetByUserName(string username);

        [Put("/api/identity/users/{id}")]
        Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input);

        [Get("/api/identity/users/{id}/roles")]
        Task<PagedResultDto<IdentityRoleDto>> GetDataRoleById(Guid id);
    }
}
