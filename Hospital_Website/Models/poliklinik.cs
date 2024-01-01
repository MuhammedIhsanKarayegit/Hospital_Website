using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Website.Models
{
    public class poliklinik
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(hastane))]

        public int hastaneId { get; set; }
        public hastane hastane { get; set; }
        public List<doktor>? Doktorlar { get; set; }
    }
}
