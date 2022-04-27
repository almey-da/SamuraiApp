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
    public class SamuraiRepo : ISamurai
    {
        private readonly SamuraiDbContext _context;

        public SamuraiRepo(SamuraiDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteSamurai = await GetById(id);
                _context.Samurais.Remove(deleteSamurai);
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

        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var result = await _context.Samurais.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Samurai>> GetAllSamuraiWithSword()
        {
            var result = await _context.Samurais.Include(s=>s.Swords).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Samurai>> GetAllSamuraiWithSwordAndElement()
        {
            var result = await _context.Samurais.Include(s => s.Swords)
                .ThenInclude(e=>e.Elements).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Samurai> GetById(int id)
        {
            var result = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data samurai id: {id} tidak ditemukan");
            return result;
        }

        public async Task<Samurai> GetByIdSamuraiWithSword(int id)
        {
            var result = await _context.Samurais.Include(s=>s.Swords).FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data samurai with sword id: {id} tidak ditemukan");
            return result;
        }

        public async Task<Samurai> GetByIdSamuraiWithSwordAndElement(int id)
        {
            var result = await _context.Samurais.Include(s => s.Swords)
                .ThenInclude(e=>e.Elements).FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data samurai with sword id: {id} tidak ditemukan");
            return result;
        }

        public async Task<IEnumerable<Samurai>> GetByName(string name)
        {
            var result = await _context.Samurais.Where(s => s.SamuraiName.Contains(name)).ToListAsync();
            if (result == null) throw new Exception($"Data samurai dengan nama: {name} tidak ditemukan");
            return result;
        }

        public async Task<Samurai> Insert(Samurai entity)
        {
            try
            {
                //ditampilkan obj yg berhasil ditambahkan
                _context.Samurais.Add(entity);
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

        public async Task<Samurai> Update(int id, Samurai entity)
        {
            try
            {
                var updateSamurai = await GetById(id);                   //ketika update diambil dari ID, ada samurai dengan id ini tidak?
                updateSamurai.SamuraiName = entity.SamuraiName;          //ketika ada baru diupdate object nya
                await _context.SaveChangesAsync();                       //mengubah status update samurai
                return updateSamurai;                                   //obj yg sudah diupdate
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
