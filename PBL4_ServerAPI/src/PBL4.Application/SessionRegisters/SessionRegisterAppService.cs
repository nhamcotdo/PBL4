using System;
using Microsoft.AspNetCore.Authorization;
using PBL4.Permissions;
using PBL4.SessionRegisters.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.SessionRegisters
{
    [Authorize]
    public class SessionRegisterAppService : CrudAppService<SessionRegister, SessionRegisterDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSessionRegisterDto, CreateUpdateSessionRegisterDto>, ISessionRegisterAppService
    {
        private readonly ISessionRegisterRepository _sessionRegisterRepository;
        public SessionRegisterAppService(ISessionRegisterRepository sessionRegisterRepository) : base(sessionRegisterRepository)
        {
            _sessionRegisterRepository = sessionRegisterRepository;
            GetPolicyName = PBL4Permissions.View;
            GetListPolicyName = PBL4Permissions.View;
            CreatePolicyName = PBL4Permissions.Create;
            UpdatePolicyName = PBL4Permissions.Update;
            DeletePolicyName = PBL4Permissions.Delete;
        }
    }
}