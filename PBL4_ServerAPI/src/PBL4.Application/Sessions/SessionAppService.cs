using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Services;
using System.Linq;
using PBL4.Sessions.Dtos;
using PBL4.SessionRegisters;
using PBL4.SessionRegisters.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace PBL4.Sessions
{
    public class SessionAppService : CrudAppService<Session, SessionDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSessionDto, CreateUpdateSessionDto>, ISessionAppService
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionAppService(ISessionRepository sessionRepository) : base(sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        
        public async Task<PagedResultDto<SessionDto>> SearchAsync(string filter = "")
        {
            var queryable = (await _sessionRepository.WithDetailsAsync())
               .WhereIf(
                   !filter.IsNullOrEmpty(),
                   x =>
                   x.Name.Contains(filter)
               );
            var sessions = await queryable.ToListAsync();
            var maxResultCount = await queryable.CountAsync();
            var rs = new PagedResultDto<SessionDto>(maxResultCount, ObjectMapper.Map<List<Session>, List<SessionDto>>(sessions));

            return rs;
        }

        public async Task CreateSessionAsync(CreateUpdateSessionDto input)
        {
            input.SessionRegisters?.ForEach(
                x => x.Id = GuidGenerator.Create()
            );
            var session = ObjectMapper.Map<CreateUpdateSessionDto, Session>(input);

            await _sessionRepository.InsertAsync(session);

            return;
        }

        public override async Task<SessionDto> UpdateAsync(Guid id, CreateUpdateSessionDto input)
        {
            var session = await _sessionRepository.GetAsync(id);

            session.SessionRegisters = new List<SessionRegister>();

            input.SessionRegisters.ForEach(
                x => x.Id = GuidGenerator.Create()
            );

            session.Name = input.Name;
            session.StartTime = input.StartTime;
            session.EndTime = input.EndTime;
            session.SessionRegisters = ObjectMapper.Map<List<CreateUpdateSessionRegisterDto>, List<SessionRegister>>(input.SessionRegisters);

            return ObjectMapper.Map<Session, SessionDto>(session);
        }
    }
}