using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL4.UserLogins
{
    /// <summary>
    /// Người dùng
    /// <para>Created: 28/09/2022</para>
    /// </summary>
    public class UserLogin : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// Họ tên
        /// </summary>
        [MaxLength(40)]
        public string Name { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        [MaxLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        [MaxLength(20)]
        public string Password { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///Địa chỉ
        /// </summary>
        [MaxLength(50)]
        public string Address { get; set; }

        /// <summary>
        /// Quyền hạng
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
    }
}