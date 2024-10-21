using Business.Services;
using Data.Services;
using DTO.DTOS.BasketDTO;
using DTO.DTOS.CompareDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class CompareManager : ICompareService
    {
        private readonly ICompareDAL _dal;
        private readonly IHttpContextAccessor _accessor;
        public CompareManager(ICompareDAL dal,IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _dal = dal;

        }

        public void AddToCompare(AddCompareDTO dto)
        {
            var compareCookie = _accessor.HttpContext.Request.Cookies["CompareCookie"];
            List<AddCompareDTO> compareList;

            if (compareCookie != null)
            {
                compareList = JsonSerializer.Deserialize<List<AddCompareDTO>>(compareCookie);
            }
            else
            {
                compareList = new List<AddCompareDTO>();
            }


            var existingItem = compareList.FirstOrDefault(x => x.ProductId == dto.ProductId);

            if (existingItem != null)
            {
                compareList.Remove(existingItem);
                compareList.Add(dto);
            }
            else
            {
                compareList.Add(dto);
            }
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30),
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            };

            var updatedCart = JsonSerializer.Serialize(compareList);
            _accessor.HttpContext.Response.Cookies.Append("CompareCookie", updatedCart, options);
        }
    

        public async Task Create(Compare entity)
        {
          await  _dal.Create(entity);
        }

        public async Task Delete(Compare entity)
        {
           await _dal.Delete(entity);   
        }

        public Task<IQueryable<Compare>> GetAll()
        {
            return _dal.GetAll();
        }

        public Compare GetById(int id)
        {
            return _dal.GetById(id);
        }

        public Compare GetById(Guid id)
        {
            return _dal.GetById(id);
        }

        public async Task Update(Compare entity)
        {
           await _dal.Update(entity);    
        }

        public async Task<int> ViewCompareCount()
        {
            return await  _dal.ViewCompareCount();
        }
    }
}
