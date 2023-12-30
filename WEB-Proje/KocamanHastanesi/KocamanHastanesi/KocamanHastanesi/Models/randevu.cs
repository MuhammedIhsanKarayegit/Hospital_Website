using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace KocamanHastanesi.Models
{
    public class randevu
    {

        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(hasta))] 
        
        public int hastaID { get; set; }
        public hasta hasta { get; set; }
        public DateTime tarih { get; set; }
        [ForeignKey(nameof(doktor))]
        public int doktorID { get; set; }
        public doktor doktor { get; set; }  
    }
}
