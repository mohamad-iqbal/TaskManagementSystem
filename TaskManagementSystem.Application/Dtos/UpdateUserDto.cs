using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Application.Dtos
{
    public class UpdateUserDto 
        {
            public string FullName { get; set; } = null!;
            public string JobTitle { get; set; } = null!;
            public UserRole Role { get; set; }
        }
}
