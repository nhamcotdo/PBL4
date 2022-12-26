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
        }
    }
}