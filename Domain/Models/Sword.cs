using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Sword
    {
        public int id { get; set; }
        public  string SwordName {get; set; }
        public int Year { get; set; }
        public int Weight { get; set; }
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }
        public List<Element> Elements { get; set; }
    }
}
