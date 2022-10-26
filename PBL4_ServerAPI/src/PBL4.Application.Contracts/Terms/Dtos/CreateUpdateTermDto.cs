using System;
using System.Collections.Generic;
using PBL4.Classes.Dtos;

namespace PBL4.Terms.Dtos
{
    public class CreateUpdateTermDto
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}