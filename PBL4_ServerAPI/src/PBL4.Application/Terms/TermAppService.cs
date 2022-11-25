using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PBL4.Terms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Terms
{
    public class TermAppService : CrudAppService<Term, TermDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateTermDto, CreateUpdateTermDto>, ITermAppService
    {
        private readonly ITermRepository _termRepository;
        public TermAppService(ITermRepository termRepository) : base(termRepository)
        {
            _termRepository = termRepository;
        }

         public async Task<PagedResultDto<TermDto>> SearchAsync(string filter = "")
        {
            var queryable = (await _termRepository.GetQueryableAsync())
               .WhereIf(
                   !filter.IsNullOrEmpty(),
                   x =>
                   x.Name.Contains(filter)
                   || x.Name.Contains(filter)
               );

            var terms = await queryable.ToListAsync();
            var maxResultCount = await queryable.CountAsync();
            var rs = new PagedResultDto<TermDto>(maxResultCount, ObjectMapper.Map<List<Term>, List<TermDto>>(terms));

            return rs;
        }
    }
}