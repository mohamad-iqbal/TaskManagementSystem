using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(int id);
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem item);
        Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(int projectId);
        Task UpdateAsync(TaskItem item);
        Task DeleteAsync(TaskItem item);
        Task SaveChangesAsync();

    }
}
