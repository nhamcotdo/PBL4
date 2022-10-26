using System;
using PBL4.Classes.Dtos;
using PBL4.Students.Dtos;
using Volo.Abp.Application.Dtos;

namespace PBL4.Registers.Dtos
{
    public class RegisterDto : EntityDto<Guid>
    {
        public string Status { get; set; }

        public float Discount { get; set; }

        public float Price { get; set; }

        public Guid ClassId { get; set; }

        public Guid StudentId { get; set; }

        public ClassDto Class { get; set; }

        public StudentDto Student { get; set; }
    }
}