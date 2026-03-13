using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Dtos;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectResponseDto> CreateProjectAsync(string name, int ownerId);
        Task<ProjectResponseDto?> GetProjectByIdAsync(int id);
        Task<IEnumerable<ProjectResponseDto>> GetAllProjectAsync();
        Task<ProjectResponseDto?> UpdateProjectAsync(int id, string newName, string newDescription);
        Task<bool> DeleteProjectAsync(int id);
    }
}
