﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetByName(string name);
        Task<T> Insert(T entity);            //entity adalah nama object, jadi bebas namanya
        Task<T> Update(int id, T entity);
        Task Delete(int id);
    }
}
