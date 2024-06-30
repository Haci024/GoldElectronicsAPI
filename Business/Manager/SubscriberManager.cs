﻿using Business.Services;
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

        public async Task Delete(Subscriber entity)
        {
            await _dal.Delete(entity);
        }

        public Task<IQueryable<Subscriber>> GetAll()
        {
             return _dal.GetAll();
        }

        public Subscriber GetById(int id)
        {
            return _dal.GetById(id);
        }

        public async Task Update(Subscriber entity)
        {
           await _dal.Update(entity);   
        }
    }
}
