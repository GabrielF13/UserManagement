using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<Guid> RegisterUserAsync(UserDto user);
        Task UpdateUserAsync(UserDto user);
        Task DeleteUserAsync(Guid Id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(Guid Id);
    }
}
