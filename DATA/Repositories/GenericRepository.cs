using Data.Connection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        private readonly GoldElectronicsDb _db;

        public GenericRepository(GoldElectronicsDb db)
        {
            _db = db;
        }

        public async Task Create(T entity)
        {
            _db.Add(entity);
             _db.SaveChanges();
        }

        public async Task Delete(T entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public  async Task<IQueryable<T>> GetAll()
        {
            return await Task.FromResult(_db.Set<T>());
        }

        public T GetById(int id)
        {
            return  _db.Set<T>().Find(id);
        }

        public async Task Update(T entity)
        {
            _db.Set<T>();
            _db.SaveChanges();
        }
    }
}
