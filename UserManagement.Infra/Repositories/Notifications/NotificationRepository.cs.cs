using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Events;

namespace UserManagement.Infra.Repositories.Notifications
{
    public class NotificationRepository : INotificationRepository
    {
        protected readonly UserManagementDbContext _context;
        protected readonly DbSet<NotificationEvent> _dbSet;

        public NotificationRepository(UserManagementDbContext context, DbSet<NotificationEvent> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public async Task<IEnumerable<NotificationEvent>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<NotificationEvent> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task CreateAsync(NotificationEvent notificationEvent)
        {
            await _dbSet.AddAsync(notificationEvent);
        }

        public async Task RemoveAsync(NotificationEvent notificationEvent)
        {
            _dbSet.Remove(notificationEvent);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
