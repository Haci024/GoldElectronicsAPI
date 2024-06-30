using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IGenericService<T> where T : class
    {
        T GetById(int id);
        Task<IQueryable<T>> GetAll();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
