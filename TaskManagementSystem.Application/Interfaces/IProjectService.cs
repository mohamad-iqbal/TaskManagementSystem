using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IProjectService
    {
        Task<Project> CreateProjectAsync(string name, int ownerId);
        Task<Project?> GetProjectByIdAsync(int id);
        Task<IEnumerable<Project>> GetAllProjectAsync();
        Task<Project?> UpdateProjectAsync(int id, string newName, string newDescription);
        Task<bool> DeleteProjectAsync(int id);
    }
}
