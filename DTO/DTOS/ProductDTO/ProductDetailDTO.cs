using DTO.DTOS.ColorDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DTOS.ProductImagesDTO;
using DTO.DTOS.DescriptionListDTO;
using DTO.DTOS.CommentDTO;

namespace DTO.DTOS.ProductDTO
{
    public class ProductDetailDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<ImageListDTO> ProductImages { get; set; }

        public ICollection<CommentListByProductDTO> CommentList {  get; set; }  

        public bool Status { get; set; }

        public decimal Price { get; set; }

        public ICollection<ColorListDTO> ColorList { get; set; }

        public bool IsSale { get; set; }

        public decimal SalesPrice { get; set; }

        public ICollection<DescriptionListByProductDTO> DescriptionList { get; set; }

        public DateTime? LastDateForIsSale { get; set; }

        public DateTime AddingDate { get; set; }

        public Guid CategoryId { get; set; }
    }
}
