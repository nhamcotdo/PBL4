using System;
using PBL4.Courses;
using PBL4.Lessons;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.LessonOfCourses
{
    public class LessonOfCourse : FullAuditedAggregateRoot<Guid>
    {
        public Guid CourseId { get; set; }

        public Guid LessonId { get; set; }

        public Course Course { get; set; }

        public Lesson Lesson { get; set; }
    }
}