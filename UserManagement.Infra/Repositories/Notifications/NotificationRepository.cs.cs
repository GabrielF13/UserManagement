using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using UserManagement.Domain.Events;

namespace UserManagement.Infra.Repositories.Notifications
{
    public class NotificationRepository : MongoRepository<NotificationEvent>, INotificationRepository
    {
        public NotificationRepository(UserManagementDbContext context)
            : base(context, "NotificationEvents")
        {
        }

        public async Task<IEnumerable<NotificationEvent>> GetByTypeAsync(NotificationType type)
        {
            var filter = Builders<NotificationEvent>.Filter.Eq(n => n.Type, type);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<NotificationEvent>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            var filter = Builders<NotificationEvent>.Filter.And(
                Builders<NotificationEvent>.Filter.Gte(n => n.Timestamp, start),
                Builders<NotificationEvent>.Filter.Lte(n => n.Timestamp, end)
            );
            return await _collection.Find(filter).ToListAsync();
        }
    }
}
