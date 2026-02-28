using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Interfaces;
using TaskManagementSystem.Infrastructure.Data;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context; // Variabel private yang menyimpan DbContext, hanya bisa diisi sekali melalui constructor, dan digunakan untuk akses database.

        public ProjectRepository(ApplicationDbContext context) // 

        {
            _context = context;
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects // Mengakses tabel Projects di database.
                .Include(p => p.Owner) // Ikut ambil data Owner yang berelasi dengan Project.
                .Include(p => p.Tasks) // Ikut ambil daftar Tasks yang dimiliki project tersebut.
                .FirstOrDefaultAsync(p => p.Id == id); // Ambil data pertama yang Id-nya sesuai, Kalau tidak ada, kembalikan null.    
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects
                .Include(p => p.Owner)
                .ToListAsync(); // Jalankan query dan ubah hasilnya menjadi List<Project>.
        }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public Task DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
