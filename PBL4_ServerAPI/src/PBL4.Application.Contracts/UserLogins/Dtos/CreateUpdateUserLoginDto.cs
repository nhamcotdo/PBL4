using System;

namespace PBL4.UserLogins.Dtos
{
    public class CreateUpdateUserLoginDto
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }

        public string Note { get; set; }
    }
}