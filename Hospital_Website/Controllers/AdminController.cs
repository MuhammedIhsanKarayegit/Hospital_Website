using Hospital_Website.Data;
using Hospital_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Website.Controllers
{
    public class AdminController : Controller
    {
        private readonly Hospital_WebsiteContext _context;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Giris(AdminLoginModel admin)
        {
            //var user = _context.hasta.FirstOrDefault(u => u.tc == hasta.tc && u.sifre == hasta.sifre);

            if (admin.Email == "G211210023@ogr.sakarya.edu.tr" || admin.Email =="G201210047@ogr.sakarya.edu.tr" && admin.Password =="sau")
            {
                HttpContext.Session.SetString("SessionUser", admin.Email);
                HttpContext.Session.SetString("kullanıcıYetki", "Admin");

                return RedirectToAction("Index", "AdminMenu");
            }

            TempData["hata"] = "Kullanıcı adı veya şifre hatalı";

            return RedirectToAction("login");
        }
    }
}
