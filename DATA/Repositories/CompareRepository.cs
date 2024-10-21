using Data.Connection;
using Data.Services;
using DTO.DTOS.CompareDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CompareRepository:GenericRepository<Compare>,ICompareDAL
    {
        private readonly GoldElectronicsDb _db;
        private readonly IHttpContextAccessor _accessor;
        public CompareRepository(GoldElectronicsDb db,IHttpContextAccessor accessor):base(db)
        {
            _db = db;
            _accessor = accessor;
        }
        public async Task<int> ViewCompareCount()
        {
            var compareCookie = _accessor.HttpContext.Request.Cookies["CompareCookie"];

            if (compareCookie != null)
            {
                var cartItems = JsonSerializer.Deserialize<IEnumerable<AddCompareDTO>>(compareCookie);
                int totalQuantity = cartItems.Count();


                return totalQuantity;
            }
            else
            {
                return 0;
            }
        }

    }
}
