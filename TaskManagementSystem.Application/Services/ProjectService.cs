using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Project> CreateProjectAsync(string name, int ownerId)
        {
            var project = new Project()
            {
                Name = name,
                OwnerId = ownerId
            };

            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();
            return project;
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Project>> GetAllProjectAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project?> UpdateProjectAsync(int id, string newName, string newDescription)
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
            return project;
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
