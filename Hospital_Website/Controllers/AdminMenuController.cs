using Microsoft.AspNetCore.Mvc;

namespace Hospital_Website.Controllers
{
    public class AdminMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
