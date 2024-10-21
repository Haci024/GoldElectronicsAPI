namespace UI.Areas.GoldManagementPanel.DTOS.ProductDTO
{
    public class MakeIsSaleDTO
    {
        public MakeIsSaleDTO()
        {
            IsSale = true;
        }
       

        public decimal SalesPrice { get; set; }

        public DateTime LastDateForIsSale { get; set; }

        public bool IsSale { get; set; }
    }
}
