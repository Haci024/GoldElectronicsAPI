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
    public class ImageListManager : ImageListService
    {
        private readonly ImageListDAL _dal;
        public ImageListManager(ImageListDAL dal)
        {
            _dal = dal;
        }
        public async Task Create(ImageList entity)
        {
           await  _dal.Create(entity);
        }

        public async Task Delete(ImageList entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<ImageList>> GetAll()
        {
            return await _dal.GetAll(); 
        }

        public ImageList GetById(int id)
        {
            return _dal.GetById(id);
        }

        public async Task Update(ImageList entity)
        {
            await _dal.Update(entity);
        }
    }
}
