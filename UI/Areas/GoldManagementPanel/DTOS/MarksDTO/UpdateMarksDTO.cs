using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Child;

namespace UI.Areas.GoldManagementPanel.DTOS.MarksDTO
{
    public class UpdateMarksDTO
    {
        public UpdateMarksDTO()
        {
            Status = true;
        }
        public bool Status { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public IEnumerable<ChildCategoryListDTO> ChildCategoryList { get; set; }



    }
}
