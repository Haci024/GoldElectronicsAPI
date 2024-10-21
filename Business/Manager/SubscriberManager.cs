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
    public class SubscriberManager : ISubscriberService
    {
        private readonly ISubscriberDAL _dal;
        public SubscriberManager(ISubscriberDAL dal)
        {
            _dal = dal;
        }
        public async Task Create(Subscriber entity)
        {
           await  _dal.Create(entity);
        }

        public async Task<int> DailySubscriberCount()
        {
            return await _dal.DailySubscriberCount();
        }

        public async Task Delete(Subscriber entity)
        {
            await _dal.Delete(entity);
        }

        public Task<IQueryable<Subscriber>> GetAll()
        {
             return _dal.GetAll();
        }

        public async Task<Subscriber> GetByEmail(string email)
        {
            return await  _dal.GetByEmail(email);
        }

        public Subscriber GetById(int id)
        {
            return _dal.GetById(id);
        }

        public Subscriber GetById(Guid id)
        {
            return _dal.GetById(id);
        }

        public async Task<int> TotalSubscriberCount()
        {
            return await  _dal.TotalSubscriberCount();
        }

        public async Task Update(Subscriber entity)
        {
           await _dal.Update(entity);   
        }

      
    }
}
