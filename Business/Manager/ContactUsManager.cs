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
    public class ContactUsManager:IContactUsService
    {
        private readonly IContactUsDAL _dal;
        public ContactUsManager(IContactUsDAL dal)
        {

            _dal = dal;

        }

        public async Task Create(ContactUs entity)
        {
            await _dal.Create(entity);  
        }

        public async Task Delete(ContactUs entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<ContactUs>> GetAll()
        {
            return await _dal.GetAll();
        }

        public ContactUs GetById(int id)
        {
            return _dal.GetById(id);    
        }

        public ContactUs GetById(Guid id)
        {
            return _dal.GetById(id);
        }

        public async Task<int> ReadMessageCount()
        {
            return await _dal.ReadMessageCount();
        }

        public Task<IQueryable<ContactUs>> ReadMessageList()
        {
            return _dal.ReadMessageList();
        }

        public async Task<IQueryable<ContactUs>> UnReadMessageList()
        {
            return await _dal.UnReadMessageList();
        }

        public async Task<int> UnReadReadMessageCount()
        {
            return await _dal.UnReadMessageCount();
        }

        public async Task Update(ContactUs entity)
        {
            await  _dal.Update(entity);
        }
    }
}
