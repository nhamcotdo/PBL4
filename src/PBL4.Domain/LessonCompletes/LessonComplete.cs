using System;
using PBL4.Classes;
using PBL4.Lessons;
using PBL4.Sessions;
using PBL4.Students;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.LessonCompletes
{
    /// <summary>
    /// Danh sách học sinh tương ứng với mỗi lớp và bài học
    /// <para>Created: 28/09/2022</para>
    /// </summary>
    public class LessonComplete :  FullAuditedAggregateRoot<Guid>
    {
        public Guid StudentId { get; set; }

        public Guid LessonId { get; set; }

        public Guid ClassId { get; set; }

        public Guid SessionId { get; set; }

        public String Comment { get; set; }

        public bool IsComplete { get; set; }

        public Student Student { get; set; }

        public Lesson Lesson { get; set; }

        public Class Class { get; set; }

        public Session Session { get; set; }
    }
}