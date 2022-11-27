using System;
using Volo.Abp.Application.Dtos;

namespace PBL4.SessionRegisters.Dtos
{
    public class CreateUpdateSessionRegisterDto : EntityDto<Guid>
    {
        public string Status { get; set; }

        public Guid StudentId { get; set; }

        public Guid SessionId { get; set; }

        public Guid ClassId { get; set; }

        public Guid? LessonId { get; set; }
    }
}