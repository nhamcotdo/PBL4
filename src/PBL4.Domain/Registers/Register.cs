using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBL4.Classes;
using PBL4.Students;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.Registers
{
    /// <summary>
    /// Danh sách đăng kí lớp học
    /// <para>Created: 14/10/2022</para>
    /// </summary>
    public class Register : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// Trạng thái(Đang đi học, huỷ, đã thanh toán,...)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Số tiền được giảm
        /// </summary>
        public float Discount { get; set; }

        /// <summary>
        /// Tiền đã nộp
        /// </summary>
        public float Price { get; set; }

        public Guid ClassId { get; set; }

        public Guid StudentId { get; set; }

        public Class Class { get; set; }

        public Student Student { get; set; }
    }
}