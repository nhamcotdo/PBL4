using System;
using PBL4.Sessions.Dtos;
using PBL4.Teachers.Dtos;

namespace PBL4.TeacherOfSessions.Dtos
{
    public class CreateUpdateTeacherOfSessionDto
    {
        public Guid TeacherId { get; set; }

        public Guid SessionId { get; set; }
    }
}