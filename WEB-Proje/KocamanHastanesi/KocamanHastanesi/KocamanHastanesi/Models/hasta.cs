﻿using System.ComponentModel.DataAnnotations.Schema;

namespace KocamanHastanesi.Models
{
    public class hasta
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tc { get; set; }
        public List<randevu>? randevular { get; set; }
        public string sifre { get; set; }
    }
}
