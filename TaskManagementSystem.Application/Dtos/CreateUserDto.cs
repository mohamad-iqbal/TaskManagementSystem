using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Application.Dtos
{
    public class CreateUserDto
    {
        public string FullName { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public UserRole Role { get; set; }
    }
}
