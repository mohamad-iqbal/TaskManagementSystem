using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Dtos;
using TaskManagementSystem.Application.Interfaces;

namespace TaskManagementSystem.API.Controllers
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
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var user = await _userService.CreateUserAsync(dto);
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userService.GetAllUsersAsync();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto dto)
        {
            var user = await _userService.UpdateUserAsync(id, dto);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }       
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok("User deleted successfully");
        }

        [HttpPut("{id}/change-password")]
        public async Task<IActionResult> ChangePassword(int id, string currentPassword, string newPassword)
        {
            await _userService.ChangePasswordAsync(id, currentPassword, newPassword);
            return Ok("Your password has been changed successfully");
        }

        [HttpPut("{id}/change-email")]
        public async Task<IActionResult> RequestEmailChange(int id, string newEmail)
        {
            await _userService.RequestEmailChangeAsync(id, newEmail);
            return Ok("Your email address has been changed");
        }
    }
}
