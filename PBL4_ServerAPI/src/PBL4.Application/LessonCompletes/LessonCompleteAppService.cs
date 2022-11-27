using System;
using Microsoft.AspNetCore.Authorization;
using PBL4.LessonCompletes.Dtos;
using PBL4.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.LessonCompletes
{
    [Authorize]
    public class LessonCompleteAppService : CrudAppService<LessonComplete, LessonCompleteDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateLessonCompleteDto, CreateUpdateLessonCompleteDto>, ILessonCompleteAppService
    {
        private readonly ILessonCompleteRepository _lessonCompleteRepository;
        public LessonCompleteAppService(ILessonCompleteRepository lessonCompleteRepository) : base(lessonCompleteRepository)
        {
            _lessonCompleteRepository = lessonCompleteRepository;
            GetPolicyName = PBL4Permissions.View;
            GetListPolicyName = PBL4Permissions.View;
            CreatePolicyName = PBL4Permissions.Create;
            UpdatePolicyName = PBL4Permissions.Update;
            DeletePolicyName = PBL4Permissions.Delete;
        }
    }
}