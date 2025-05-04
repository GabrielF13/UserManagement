using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Events
{
    public class NotificationEvent
    {
        public NotificationEvent(Guid id, NotificationType type, DateTime timestamp, Dictionary<string, string> data)
        {
            Id = id;
            Type = type;
            Timestamp = timestamp;
            Data = data;
        }

        public Guid Id { get; set; }
        public NotificationType Type{ get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, string> Data { get; set; }

    }
}
