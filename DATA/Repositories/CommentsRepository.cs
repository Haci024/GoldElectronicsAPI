using Data.Connection;
using Data.Services;
using DTO.DTOS.CommentDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CommentsRepository:GenericRepository<Comments>,ICommentDAL
    {
        private readonly GoldElectronicsDb _db;
        public CommentsRepository(GoldElectronicsDb db):base(db)
        {
            _db= db;
        }

        public async Task<IQueryable<Comments>> CommentListByProduct(Guid productId)
        {
            return  _db.Comments.Include(x=>x.Product).Where(x=>x.ProductId==productId).OrderBy(x=>x.MessageDate);
        }

        public async Task<CommentRatedPercentDTO> GetCommentRatedPercent(Guid ProductId)
        {
            var query =await _db.Products.Where(x => x.Id == ProductId).Include(x=>x.Comments).Select(x=>new CommentRatedPercentDTO { 
            
                
                OneStarCount=x.Comments.Where(x=>x.Rate==1).Count(),
                TwoStarCount = x.Comments.Where(x => x.Rate == 2).Count(),
                ThreeStarCount = x.Comments.Where(x => x.Rate == 3).Count(),
                FourthStarCount = x.Comments.Where(x => x.Rate == 4).Count(),
                FiveStarCount = x.Comments.Where(x => x.Rate == 5).Count(),
                OneStarRange=(int)((x.Comments.Where(x=>x.Rate==1).Count()*100))/(decimal)(x.Comments.Count()),
                TwoStarRange=(int)((x.Comments.Where(x => x.Rate == 2).Count() * 100)) /(decimal)(x.Comments.Count()),
                ThreeStarRange =(int)((x.Comments.Where(x => x.Rate == 3).Count() * 100)) /(decimal) (x.Comments.Count()),
                FourthStarRange = (int)((x.Comments.Where(x => x.Rate == 4).Count() * 100)) /(decimal)(x.Comments.Count()),
                FiveStarRange=((x.Comments.Where(x => x.Rate == 5).Count() * 100)) /(decimal)(x.Comments.Count()),
                AverageStarCount= (x.Comments.Where(x => x.Rate == 1).Count()*1+x.Comments.Where(x=>x.Rate==2).Count()*2+x.Comments.Where(x=>x.Rate==3).Count()*3+x.Comments.Where(x=>x.Rate==4).Count()*4+x.Comments.Where(x=>x.Rate==5).Count()*5)/(decimal)x.Comments.Count(),
                CommentCount=x.Comments.Count()
            }).FirstOrDefaultAsync();

            return query;
        }
    }
}
