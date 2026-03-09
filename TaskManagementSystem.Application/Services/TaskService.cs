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
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskItem> CreateTaskAsync(CreateTaskDto dto)
        {
            var task = new TaskItem()
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
                ProjectId = dto.ProjectId,
                CreatedByUserId = dto.CreatedByUserId,
                AssignedToUserId = dto.AssignedToUserId,
                DueDate = dto.DueDate
            };

            await _taskRepository.AddAsync(task);
            await _taskRepository.SaveChangesAsync();
            return task;
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetAllTaskAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _taskRepository.GetTasksByProjectIdAsync(projectId);
        }

        public async Task<TaskItem?> UpdateTaskAsync(int id, UpdateTaskDto dto)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
            {
                return null;
            }

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Status = dto.Status;
            task.AssignedToUserId = dto.AssignedToUserId;
            task.DueDate = dto.DueDate;

            await _taskRepository.UpdateAsync(task);
            await _taskRepository.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
            {
                return false;
            }

            await _taskRepository.DeleteAsync(task);
            await _taskRepository.SaveChangesAsync();

            return true;
        }
    }
}
