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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectResponseDto> CreateProjectAsync(string name, int ownerId)
        {
            var project = new Project()
            {
                Name = name,
                OwnerId = ownerId
            };

            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();

            var savedProject = await _projectRepository.GetByIdAsync(project.Id);

            return new ProjectResponseDto
            {
                Id = savedProject.Id,
                Name = savedProject.Name,
                Description = savedProject.Description,
                OwnerName = savedProject.Owner.FullName,
                CreatedAt = savedProject.CreatedAt
            };
        }

        public async Task<ProjectResponseDto?> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                return null;

            return new ProjectResponseDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                OwnerName = project.Owner.FullName,
                CreatedAt = project.CreatedAt
            };
        }

        public async Task<IEnumerable<ProjectResponseDto>> GetAllProjectAsync()
        {
            var project = await _projectRepository.GetAllAsync();
            return project.Select(p => new ProjectResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                OwnerName = p.Owner.FullName,
                CreatedAt = p.CreatedAt
            });
        }

        public async Task<ProjectResponseDto?> UpdateProjectAsync(int id, string newName, string newDescription)
        {
            // Ambil project dari database
            var project = await _projectRepository.GetByIdAsync(id);

            // Return null jika tidak ada
            if (project == null)
                return null;

            // Update property yang diubah
            project.Name = newName;
            project.Description = newDescription;

            // Simpan perubahan
            await _projectRepository.UpdateAsync(project);
            await _projectRepository.SaveChangesAsync();

            // Kembalikan project
            return new ProjectResponseDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                OwnerName = project.Owner.FullName,
                CreatedAt = project.CreatedAt
            };
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            // Ambil project dari database
            var project = await _projectRepository.GetByIdAsync(id);

            // Return Null jika tidak ada
            if (project == null)
                return false;

            // Hapus project/data
            await _projectRepository.DeleteAsync(project);
            await _projectRepository.SaveChangesAsync();
            return true;
        }
    }
}
