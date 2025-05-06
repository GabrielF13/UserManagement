using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<Guid> RegisterUserAsync(UserDto user);

        Task<bool> UpdateUserAsync(Guid id, UserDto user);

        Task<bool> DeleteUserAsync(Guid id);

        Task<User> GetByEmailAsync(string email);

        Task<User> GetByIdAsync(Guid id);
    }
}