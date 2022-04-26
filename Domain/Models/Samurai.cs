using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Samurai
    {
        public int Id { get; set; }
        public string SamuraiName { get; set; }
        public List<Sword> Swords { get; set; }
    }
}
