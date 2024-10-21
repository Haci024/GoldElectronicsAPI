using Data.Repositories;
using DTO.DTOS.ProductImagesDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ImageListDAL:IGenericDAL<ImageList>
    {
        Task<IQueryable<ImageListDTO>> ImageListByProduct(Guid productId);
    }
}
