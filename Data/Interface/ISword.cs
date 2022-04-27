using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ISword:ICrud<Sword>
    {
        Task<IEnumerable<Sword>> GetAllSwordWithElement();        //nampilin semuasamurai dg semua sword
        Task<Sword> GetByIdSwordWithElement(int id);
    }
}
