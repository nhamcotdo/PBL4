using System;
using Microsoft.AspNetCore.Authorization;
using PBL4.Permissions;
using PBL4.Registers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Registers
{
    [Authorize]
    public class RegisterAppService : CrudAppService<Register, RegisterDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateRegisterDto, CreateUpdateRegisterDto>, IRegisterAppService
    {
        private readonly IRegisterRepository _registerRepository;
        public RegisterAppService(IRegisterRepository registerRepository) : base(registerRepository)
        {
            _registerRepository = registerRepository;
             GetPolicyName = PBL4Permissions.View;
            GetListPolicyName = PBL4Permissions.View;
            CreatePolicyName = PBL4Permissions.Create;
            UpdatePolicyName = PBL4Permissions.Update;
            DeletePolicyName = PBL4Permissions.Delete;
        }
    }
}