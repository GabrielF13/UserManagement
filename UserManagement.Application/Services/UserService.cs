using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Services;
using UserManagement.Infra.Repositories.Users;

namespace UserManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);

                if (user == null)
                    throw new InvalidOperationException("Usuário não encontrado");

                await _userRepository.DeleteAsync(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<User> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user is null)
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            return user;
        }

        public async Task<Guid> RegisterUserAsync(UserDto userDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException($"Usuário com e-mail {userDto.Email} já existe.");
            }

            var user = new User(userDto.Name, userDto.Email);
            await _userRepository.CreateAsync(user);

            var notificationData = new Dictionary<string, string>
            {
                ["UserId"] = user.Id.ToString(),
                ["UserName"] = user.Name,
                ["UserEmail"] = user.Email
            };

            //var notificationEvent = new NotificationEvent(NotificationType.UserRegistration, notificationData);

            // Publicar evento no message broker
            //await _messageBroker.PublishAsync("notifications", notificationEvent);

            return user.Id;
        }

        public async Task<bool> UpdateUserAsync(Guid id, UserDto userDto)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);

                if (user is null)
                {
                    throw new InvalidOperationException("Usuário não encontrado");
                }

                var updateUser = new User(id, userDto.Name, userDto.Email);

                await _userRepository.UpdateAsync(user.Id, updateUser);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}