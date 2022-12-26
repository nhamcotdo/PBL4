using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PBL4.Classes.Dtos;
using Volo.Abp.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Services;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using PBL4.Permissions;

namespace PBL4.Classes
{
    [Authorize]
    public class ClassAppService : CrudAppService<Class, ClassDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateClassDto, CreateUpdateClassDto>, IClassAppService
    {
        private readonly IClassRepository _classRepository;
        public ClassAppService(IClassRepository classRepository) : base(classRepository)
        {
            _classRepository = classRepository;
            GetPolicyName = PBL4Permissions.Class.Get;
            GetListPolicyName = PBL4Permissions.Class.Get;
            CreatePolicyName = PBL4Permissions.Class.Create;
            UpdatePolicyName = PBL4Permissions.Class.Update;
            DeletePolicyName = PBL4Permissions.Class.Delete;
        }

        [AllowAnonymous]
        public async Task<PagedResultDto<ClassDto>> SearchAsync(string filter = "")
        {
            var queryable = (await _classRepository.WithDetailsAsync())
               .WhereIf(
                   !filter.IsNullOrEmpty(),
                   x =>
                   x.Name.Contains(filter)
                   || x.Term.Name.Contains(filter)
               );
            var classs = await queryable.ToListAsync();
            var maxResultCount = await queryable.CountAsync();
            var rs = new PagedResultDto<ClassDto>(maxResultCount, ObjectMapper.Map<List<Class>, List<ClassDto>>(classs));

            return rs;
        }

        [Authorize(PBL4Permissions.Class.Get)]
        public override async Task<ClassDto> GetAsync(Guid id)
        {
            var queryable = await _classRepository.WithDetailsAsync();

            return ObjectMapper.Map<Class, ClassDto>(await queryable
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync());
        }
    }
}