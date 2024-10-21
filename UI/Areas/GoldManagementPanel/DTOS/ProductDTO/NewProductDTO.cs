using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Child;
using UI.Areas.GoldManagementPanel.DTOS.MarksDTO;

namespace UI.Areas.GoldManagementPanel.DTOS.ProductDTO
{
    public class NewProductDTO
    {
        public NewProductDTO()
        {
            Status = true;
        }
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public ICollection<ThirdLevelCategoryDTO> ThirdLevelCategories { get; set; }

        public ICollection<MarkListDTO> MarkList { get; set; }

        public int MarksId {  get; set; }

        public IFormFile[] ProductImages { get; set; }

        public bool Status { get; set; }

        public decimal Price { get; set; }

        public bool IsSale { get; set; }

        public decimal SalesPrice { get; set; }

        public DateTime LastDateForIsSale { get; set; }
    }
}
