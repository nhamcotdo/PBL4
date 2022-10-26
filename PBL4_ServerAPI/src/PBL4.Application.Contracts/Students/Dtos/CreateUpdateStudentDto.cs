using System;
using System.ComponentModel.DataAnnotations;
using PBL4.UserLogins.Dtos;

namespace PBL4.Students.Dtos
{
    public class CreateUpdateStudentDto
    {
        [MaxLength(40)]
        public string ParentName { get; set; }

        public UserLoginDto UserLogin { get; set; }
    }
}