
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PBL4.Classes;
using PBL4.LessonOfCourses;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.Courses
{
    /// <summary>
    /// Khoá học
    /// <para>Author: Nhamcotdo</para>
    /// <para>Created: 28/09/2022</para>
    /// </summary>
    public class Course : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// Tên Khoá học
        /// </summary>
        [MaxLength(40)]
        public string Name { get; set; }

        /// <summary>
        /// Mô tả Khoá học
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Số lượng bài học trong Khoá học
        /// </summary>
        public int NumberOfLesson { get; set; }

        public ICollection<Class> Classes { get; set; }

        public ICollection<LessonOfCourse> LessonOfCourses { get; set; }

        public Course()
        {
            Classes = new HashSet<Class>();
            LessonOfCourses = new HashSet<LessonOfCourse>();
        }
    }
}