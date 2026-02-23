using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
