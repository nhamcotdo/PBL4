using System;
using PBL4.SessionRegisters.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.SessionRegisters
{
    public class SessionRegisterAppService : CrudAppService<SessionRegister, SessionRegisterDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSessionRegisterDto, CreateUpdateSessionRegisterDto>, ISessionRegisterAppService
    {
        private readonly ISessionRegisterRepository _sessionRegisterRepository;
        public SessionRegisterAppService(ISessionRegisterRepository sessionRegisterRepository) : base(sessionRegisterRepository)
        {
            _sessionRegisterRepository = sessionRegisterRepository;
        }
    }
}