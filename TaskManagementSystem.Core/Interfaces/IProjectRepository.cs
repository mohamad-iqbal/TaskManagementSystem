using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(int id); // ambil 1 data dari DB
        Task<IEnumerable<Project>> GetAllAsync(); // Ambil semua data , IEnumerable mengambil semua seperti list tapi hanya bisa Read saja
        Task AddAsync(Project project);
        Task DeleteAsync(Project project);
        Task UpdateAsync(Project project);
        Task SaveChangesAsync();
    }
}
