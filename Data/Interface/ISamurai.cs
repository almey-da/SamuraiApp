using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ISamurai:ICrud<Samurai>
    {
        Task<IEnumerable<Samurai>> GetAllSamuraiWithSword();        //nampilin semuasamurai dg semua sword
        Task<Samurai> GetByIdSamuraiWithSword(int id);
        Task<IEnumerable<Samurai>> GetAllSamuraiWithSwordAndElement();        //nampilin semuasamurai dg semua sword
        Task<Samurai> GetByIdSamuraiWithSwordAndElement(int id);

    }
}
