using Microsoft.AspNetCore.Mvc;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Interfaces.Services;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
        {
            try
            {
                var userId = await _userService.RegisterUserAsync(userDto);
                return CreatedAtAction(nameof(GetUser), new { id = userId }, userId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao registrar usuário: {ex.Message}");
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto userDto)
        {
            var updated = await _userService.UpdateUserAsync(id, userDto);

            if (updated)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] Guid id)
        {
            var updated = await _userService.DeleteUserAsync(id);

            if (updated)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}