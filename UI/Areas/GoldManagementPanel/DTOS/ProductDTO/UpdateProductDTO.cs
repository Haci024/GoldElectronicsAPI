using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Child;
using UI.Areas.GoldManagementPanel.DTOS.MarksDTO;

namespace UI.Areas.GoldManagementPanel.DTOS.ProductDTO
{
    public class UpdateProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public bool Status { get; set; }

        public decimal Price { get; set; }

        public bool IsSale { get; set; }

        public decimal SalesPrice { get; set; }

        public ICollection<ThirdLevelCategoryDTO> ThirdLevelCategories { get; set; }
    }
}
