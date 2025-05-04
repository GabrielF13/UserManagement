using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;

namespace UserManagement.Infra.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        protected readonly UserManagementDbContext _context;
        protected readonly DbSet<User> _dbSet;

        public UserRepository(UserManagementDbContext context, DbSet<User> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task CreateAsync(User user)
        {
            await _dbSet.AddAsync(t);
        }

        public async Task RemoveAsync(User user)
        {
            _dbSet.Remove(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}