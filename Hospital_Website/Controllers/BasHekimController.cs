using Hospital_Website.Data;
using Hospital_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Website.Controllers
{
    public class BasHekimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Giris(BasHekimModel basHekim)
        {
            //var user = _context.hasta.FirstOrDefault(u => u.tc == hasta.tc && u.sifre == hasta.sifre);

            if (basHekim.Email == "mkarayegit21@gmail.com" && basHekim.Password == "sau")
            {
                HttpContext.Session.SetString("SessionUser", basHekim.Email);
                HttpContext.Session.SetString("kullanıcıYetki", "BasHekim");

                return RedirectToAction("Index", "BasHekimMenu");
            }

            TempData["hata"] = "Kullanıcı adı veya şifre hatalı";

            return RedirectToAction("Index");
        }
    }
}
