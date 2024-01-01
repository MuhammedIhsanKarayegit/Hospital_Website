using Hospital_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Website.Controllers
{
    public class AyaxController : Controller
    {
        private readonly Hospital_WebsiteContext dbContext;

        public AyaxController(Hospital_WebsiteContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public JsonResult GetIlceler(int cityId)
        {
            var ilceler = dbContext.ilce
                .Where(i => i.ilID == cityId)
                .Select(i => new { Value = i.id, Text = i.name })
                .ToList();

            return Json(ilceler);
        }

        [HttpGet]
        public JsonResult GetHastaneler(int ilceId)
        {
            var hastaneler = dbContext.hastane
                .Where(h => h.ilceID == ilceId)
                .Select(h => new { Value = h.Id, Text = h.Name })
                .ToList();

            return Json(hastaneler);
        }

        [HttpGet]
        public JsonResult GetPoliklinikler(int hastaneId)
        {
            var poliklinikler = dbContext.poliklinik
                .Where(p => p.hastaneId == hastaneId)
                .Select(p => new { Value = p.Id, Text = p.Name })
                .ToList();

            return Json(poliklinikler);
        }

        [HttpGet]
        public JsonResult GetDoktorlar(int poliklinikId)
        {
            var doktorlar = dbContext.doktor
                .Where(d => d.poliklinikid == poliklinikId)
                .Select(d => new { Value = d.id, Text = d.name })
                .ToList();

            return Json(doktorlar);
        }
    }
}
