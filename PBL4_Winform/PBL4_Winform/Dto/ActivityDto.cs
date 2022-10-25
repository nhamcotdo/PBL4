using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PBL4_Winform.Dto
{
    public class ActivityDto : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Level { get; set; }

        public DateTime NotificationScheduleTime { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Place { get; set; }

        public int Quantity { get; set; }

        public int NumberOfCheckin { get; set; }

        public float Point { get; set; }

        public string Note { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string UnitName { get; set; }

        public bool IsPushNotification { get; set; }

        public string ActivitySlug { get; set; }
    }
}
