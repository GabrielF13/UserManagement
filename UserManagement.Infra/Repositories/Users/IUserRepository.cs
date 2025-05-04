using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Infra.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByEmailAsync(string email);

        Task CreateAsync(User user);
    }
}
