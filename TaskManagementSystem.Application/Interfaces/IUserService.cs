using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Dtos;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserDto dto);
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User?> UpdateUserAsync(int id, UpdateUserDto dto);
        Task ChangePasswordAsync(
            int userId,
            string currentPassword,
            string newPassword);
        Task RequestEmailChangeAsync(int userId, string newEmail);
        Task<bool> DeleteUserAsync(int id);
    }
}
