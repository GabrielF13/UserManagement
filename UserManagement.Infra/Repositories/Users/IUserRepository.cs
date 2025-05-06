using UserManagement.Domain.Entities;

namespace UserManagement.Infra.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByEmailAsync(string email);

        Task CreateAsync(User user);

        Task UpdateAsync(Guid id, User entity);

        Task DeleteAsync(Guid id);
    }
}