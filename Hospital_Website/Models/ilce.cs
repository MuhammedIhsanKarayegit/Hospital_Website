using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Website.Models
{
    public class ilce
    {
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey(nameof(il))]
        public int  ilID { get; set; }
        public il il { get; set; }

        public List<hastane>? hastaneler { get; set; }

    }
}
