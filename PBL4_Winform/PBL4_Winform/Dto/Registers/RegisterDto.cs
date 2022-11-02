using PBL4_Winform.Dto.Classes;
using PBL4_Winform.Dto.Student;
using System;

namespace PBL4_Winform.Dto.Registers

{
    public class RegisterDto
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
