using UserManagement.Domain.Events;

namespace UserManagement.Domain.Dtos
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public NotificationType Type { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }
}
