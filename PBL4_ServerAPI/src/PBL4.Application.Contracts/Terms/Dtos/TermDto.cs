using System;
using System.Collections.Generic;
using PBL4.Classes.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.Terms.Dtos
{
    public class TermDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        // public ICollection<ClassDto> Classes { get; set; }
    }
}