﻿using System;

namespace PBL4_Winform.Dto.Terms
{
    public class TermDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
