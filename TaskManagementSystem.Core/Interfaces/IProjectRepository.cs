using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Core.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(int id); // ambil 1 data dari DB
        Task<IEnumerable<Project>> GetAllAsync(); // Ambil semua data , IEnumerable mengambil semua seperti list tapi hanya bisa Read saja
        Task AddAsync(Project project);
        Task DeleteAsync(Project project);
        Task SaveChangesAsync();
    }
}
