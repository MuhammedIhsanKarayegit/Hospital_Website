using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Website.Models
{
    public class doktor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tc { get; set; }

        [ForeignKey("poliklinik")]        
        
        public int poliklinikid { get; set; } 
        public poliklinik poliklinik { get; set; }

        public string sifre { get; set; }
    }
}
