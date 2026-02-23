using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Web.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
