using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hospital_Website.Models;

namespace Hospital_Website.Data
{
    public class Hospital_WebsiteContext : DbContext
    {
        public Hospital_WebsiteContext (DbContextOptions<Hospital_WebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<Hospital_Website.Models.doktor> doktor { get; set; } = default!;

        public DbSet<Hospital_Website.Models.hasta>? hasta { get; set; }

        public DbSet<Hospital_Website.Models.hastane>? hastane { get; set; }

        public DbSet<Hospital_Website.Models.il>? il { get; set; }

        public DbSet<Hospital_Website.Models.ilce>? ilce { get; set; }

        public DbSet<Hospital_Website.Models.poliklinik>? poliklinik { get; set; }

        public DbSet<Hospital_Website.Models.randevu>? randevu { get; set; }
    }
}
