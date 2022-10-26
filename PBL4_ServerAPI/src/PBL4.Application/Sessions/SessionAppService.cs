using System;
using PBL4.Sessions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Sessions
{
    public class SessionAppService : CrudAppService<Session, SessionDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSessionDto, CreateUpdateSessionDto>, ISessionAppService
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionAppService(ISessionRepository sessionRepository) : base(sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
    }
}