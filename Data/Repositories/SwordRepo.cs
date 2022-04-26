using Data.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SwordRepo : ISword
    {
        private readonly SamuraiDbContext _context;

        public SwordRepo(SamuraiDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteSword = await GetById(id);
                _context.Swords.Remove(deleteSword);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Sword>> GetAll()
        {
            var result = await _context.Swords.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Sword> GetById(int id)
        {
            var result = await _context.Swords.FirstOrDefaultAsync(s => s.id == id);
            if (result == null) throw new Exception($"Data Sword id: {id} tidak ditemukan");
            return result;
        }

        public async Task<IEnumerable<Sword>> GetByName(string name)
        {
            var result = await _context.Swords.Where(s => s.SwordName.Contains(name)).ToListAsync();
            if (result == null) throw new Exception($"Data Sword dengan nama: {name} tidak ditemukan");
            return result;
        }

        public  async Task<Sword> Insert(Sword entity)
        {
            try
            {
                //ditampilkan obj yg berhasil ditambahkan
                _context.Swords.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Sword> Update(int id, Sword entity)
        {
            try
            {
                var updateSword = await GetById(id);                   //ketika update diambil dari ID, ada Sword dengan id ini tidak?
                
                updateSword.SwordName = entity.SwordName;          //ketika ada baru diupdate object nya
                updateSword.Year = entity.Year;
                updateSword.Weight = entity.Weight;
                updateSword.SamuraiId = entity.SamuraiId;
                await _context.SaveChangesAsync();                       //mengubah status update Sword
                return updateSword;                                   //obj yg sudah diupdate
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
