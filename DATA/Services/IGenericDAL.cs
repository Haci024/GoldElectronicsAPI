using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IGenericDAL<T> where T : class
    {
        Task<IQueryable<T>> GetAll();
        
        T GetById(int id); 

        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);

        
    }
}
