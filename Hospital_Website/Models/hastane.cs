using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Website.Models
{



    public class hastane
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<poliklinik> poliklinikler { get; set; }
        [ForeignKey(nameof(ilce))]

        public int ilID { get; set; }
        public int ilceID { get; set; }

        public ilce ilce { get; set; }
    }
}