using System;
using PBL4.Classes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Classes
{
    public class ClassAppService : CrudAppService<Class, ClassDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateClassDto, CreateUpdateClassDto>, IClassAppService
    {
        private readonly IClassRepository _classRepository;
        public ClassAppService(IClassRepository classRepository) : base(classRepository)
        {
            _classRepository = classRepository;
        }
    }
}