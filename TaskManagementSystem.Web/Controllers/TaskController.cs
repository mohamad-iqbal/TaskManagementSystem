using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Web.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
