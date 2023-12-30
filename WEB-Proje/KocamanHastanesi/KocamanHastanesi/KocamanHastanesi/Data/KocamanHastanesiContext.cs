using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KocamanHastanesi.Models;

namespace KocamanHastanesi.Data
{
    public class KocamanHastanesiContext : DbContext
    {
        public KocamanHastanesiContext (DbContextOptions<KocamanHastanesiContext> options)
            : base(options)
        {
        }

        public DbSet<KocamanHastanesi.Models.doktor> doktor { get; set; } = default!;

        public DbSet<KocamanHastanesi.Models.hasta>? hasta { get; set; }

        public DbSet<KocamanHastanesi.Models.hastane>? hastane { get; set; }

        public DbSet<KocamanHastanesi.Models.il>? il { get; set; }

        public DbSet<KocamanHastanesi.Models.ilce>? ilce { get; set; }

        public DbSet<KocamanHastanesi.Models.poliklinik>? poliklinik { get; set; }

        public DbSet<KocamanHastanesi.Models.randevu>? randevu { get; set; }
    }
}
