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

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            return Ok(new { Id = id, Message = "Método de obtenção de detalhes do usuário" });
        }
    }
}
