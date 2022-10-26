using System;
using PBL4.Registers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Registers
{
    public class RegisterAppService : CrudAppService<Register, RegisterDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateRegisterDto, CreateUpdateRegisterDto>, IRegisterAppService
    {
        private readonly IRegisterRepository _registerRepository;
        public RegisterAppService(IRegisterRepository registerRepository) : base(registerRepository)
        {
            _registerRepository = registerRepository;
        }
    }
}