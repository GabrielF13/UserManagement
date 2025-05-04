using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using UserManagement.Domain.Entities;

namespace UserManagement.Infra.Repositories.Users
{
    public class UserRepository : MongoRepository<User>, IUserRepository
    {
        public UserRepository(UserManagementDbContext context)
            : base(context, "Users")
        { 
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}