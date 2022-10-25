using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using PBL4_Winform.Dto;

namespace PBL4_Winform.SdkCommon
{
    public interface IActivitiesApi
    {
        [Get("/api/app/activity/{id}")]
        Task<ActivityDto> GetAsync(Guid id);


        [Get("/api/app/activity")]
        Task<PagedResultDto<ActivityDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
