using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Dtos;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface ITaskService
    {
        Task<TaskItem> CreateTaskAsync(CreateTaskDto dto);
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task<IEnumerable<TaskItem>> GetAllTaskAsync();
        Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(int projectId);
        Task<TaskItem?> UpdateTaskAsync(int id, UpdateTaskDto dto);
        Task<bool> DeleteTaskAsync(int id);
    }
}
