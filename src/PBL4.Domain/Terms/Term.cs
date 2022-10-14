using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PBL4.Classes;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.Terms
{
    /// <summary>
    /// Kì học
    /// <para>Created: 28/09/2022</para>
    /// </summary>
    public class Term : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// Họ tên
        /// </summary>
        [MaxLength(40)]
        public string Name { get; set; }

        /// <summary>
        /// Thời gian bắt đầu
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Thời gian kết thúc
        /// </summary>
        public DateTime EndTime { get; set; }

        public ICollection<Class> Classes { get; set; }

        public Term()
        {
            Classes = new HashSet<Class>();
        }
    }
}