using Microsoft.AspNetCore.Mvc;

namespace Hospital_Website.Controllers
{
    public class BasHekimMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
