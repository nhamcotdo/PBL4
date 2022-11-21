using System;
using PBL4.Classes.Dtos;
using PBL4.Lessons.Dtos;
using PBL4.Sessions.Dtos;
using PBL4.Students.Dtos;
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