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
    public class ElementRepo : IElement
    {
        private readonly SamuraiDbContext _context;

        public ElementRepo(SamuraiDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteElement = await GetById(id);
                _context.Elements.Remove(deleteElement);
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

        public async Task<IEnumerable<Element>> GetAll()
        {
            var result = await _context.Elements.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Element> GetById(int id)
        {
            var result = await _context.Elements.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Element id: {id} tidak ditemukan");
            return result;
        }

        public async Task<IEnumerable<Element>> GetByName(string name)
        {
            var result = await _context.Elements.Where(s => s.Name.Contains(name)).ToListAsync();
            if (result == null) throw new Exception($"Data Element dengan nama: {name} tidak ditemukan");
            return result;
        }

        public  async Task<Element> Insert(Element entity)
        {
            try
            {
                //ditampilkan obj yg berhasil ditambahkan
                _context.Elements.Add(entity);
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

        public async Task<Element> Update(int id, Element entity)
        {
            try
            {
                var updateElement = await GetById(id);                   //ketika update diambil dari ID, ada Element dengan id ini tidak?
                updateElement.Name = entity.Name;          //ketika ada baru diupdate object nya
                await _context.SaveChangesAsync();                       //mengubah status update Element
                return updateElement;                                   //obj yg sudah diupdate
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
