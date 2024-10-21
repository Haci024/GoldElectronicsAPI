using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.DTOS.CommentsDTO
{
    public class CommentRatedPercentDTO
    {
        public Guid productId { get; set; }

        public int OneStarCount { get; set; }

        public int TwoStarCount { get; set; }

        public int ThreeStarCount { get;set; }

        public int FourthStarCount { get; set; }

        public int FiveStarCount { get; set; }
           
        public decimal AverageStarCount { get; set; }

        public decimal OneStarRange { get;  set; }

        public decimal TwoStarRange { get; set;}

        public decimal ThreeStarRange { get;set; }

        public decimal FourthStarRange { get;  set; }

        public decimal FiveStarRange { get;  set; }

        public int CommentCount { get; set; }
    }
}
