using UserManagement.Domain.Events;

namespace UserManagement.Infra.Repositories.Notifications
{
    public interface INotificationRepository
    {
        Task<NotificationEvent> GetByIdAsync(Guid id);

        Task<IEnumerable<NotificationEvent>> GetAllAsync();

        Task CreateAsync(NotificationEvent notificationEvent);
    }
}