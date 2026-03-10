using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Interfaces;

namespace TaskManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(string name, int ownerId)
        {
            var project = await _projectService.CreateProjectAsync(name, ownerId);
            return Ok(project);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProject()
        {
            var project = await _projectService.GetAllProjectAsync();
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProjectAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok("Project deleted successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, string newName, string newDescription)
        {
            var project = await _projectService.UpdateProjectAsync(id, newName, newDescription);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }
    }
}
