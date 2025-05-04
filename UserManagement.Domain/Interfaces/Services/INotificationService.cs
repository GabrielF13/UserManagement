using UserManagement.Domain.Events;

namespace UserManagement.Domain.Interfaces.Services
{
    public interface INotificationService
    {
        Task SendNotificationAsync(NotificationEvent notificationEvent);
    }
}