using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task Add(User user);
        Task Update(User user);
        Task Delete(Guid Id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(Guid Id);
    }
}
