using System;
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
    }
}