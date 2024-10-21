
using Business.Services;
using Data.Services;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class OrderManager:IOrderService
    {
     private readonly IOrderDAL _orderDAL;
            public OrderManager(IOrderDAL orderDAL)
            {
                _orderDAL = orderDAL;
            }
            public async Task Create(Orders entity)
            {
                await _orderDAL.Create(entity);
            }

            public async Task Delete(Orders entity)
            {
                await _orderDAL.Delete(entity);
            }

            public async Task<IQueryable<Orders>> GetAll()
            {
                return await _orderDAL.GetAll();
            }

            public Orders GetById(int id)
            {
                return _orderDAL.GetById(id);
            }

        public Orders GetById(Guid id)
        {
            return _orderDAL.GetById(id);
        }

        public async Task Update(Orders entity)
            {
                await _orderDAL.Update(entity);
            }
        
    }
}
