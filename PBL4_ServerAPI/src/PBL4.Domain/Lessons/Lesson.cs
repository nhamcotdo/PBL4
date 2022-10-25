
using System;
using System.Collections.Generic;
using PBL4.LessonCompletes;
using PBL4.LessonOfCourses;
using PBL4.Sessions;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.Lessons
{
    /// <summary>
    /// Buổi học
    /// <para>Author: Nhamcotdo</para>
    /// <para>Created: 28/09/2022</para>
    /// </summary>
    public class Lesson : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// Tiêu đề
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Link tài liệu
        /// </summary>
        public string DocumentUrl { get; set; }

        /// <summary>
        /// Thời gian 1 bài học
        /// </summary>
        public float TimePerLesson { get; set; }

        /// <summary>
        /// Hướng dẫn
        /// </summary>
        public string Guide { get; set; }

        public ICollection<Session> Sessions { get; set; }

        public ICollection<LessonOfCourse> LessonOfCourses { get; set; }

        public ICollection<LessonComplete> LessonCompletes { get; set; }
        
        public Lesson()
        {
            Sessions = new HashSet<Session>();
            LessonOfCourses = new HashSet<LessonOfCourse>();
            LessonCompletes = new HashSet<LessonComplete>();
        }
    }
}