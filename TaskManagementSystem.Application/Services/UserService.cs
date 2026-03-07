using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Dtos;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;

namespace TaskManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(CreateUserDto dto)
        {
            // Existing Email Check
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }

            // Create new user
            var user = new User()
            {
                FullName = dto.FullName,
                JobTitle = dto.JobTitle,
                Email = dto.Email,
                PasswordHash = dto.Password,
                Role = dto.Role,
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return null;

            user.FullName = dto.FullName;
            user.JobTitle = dto.JobTitle;
            user.Role = dto.Role;

            await _userRepository.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) 
                return false;

            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveChangesAsync();

            return true;
        }

        public async Task ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            // 1. Ambil user dari database
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            // 2. Verifikasi password lama
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(currentPassword, user.PasswordHash);

            if (!isPasswordValid)
            {
                throw new Exception("Current password is incorrect");
            }

            // 3. Hash password baru
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // 4. Update password
            user.PasswordHash = hashedPassword;

            // 5. Simpan perubahan
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task RequestEmailChangeAsync(int userId, string newEmail)
        {
            // Check already email
            var existingUser = await _userRepository.GetByEmailAsync(newEmail);

            if (existingUser != null)
            {
                throw new Exception("Email already in use");
            }

            // Get user
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Update new email
            user.Email = newEmail;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
