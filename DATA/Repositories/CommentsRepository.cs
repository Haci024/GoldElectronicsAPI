using Data.Connection;
using Data.Services;
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

        public async Task<IQueryable<Comments>> CommentListByProduct(int productId)
        {
            return  _db.Comments.Include(x=>x.Product).Where(x=>x.ProductId==productId).OrderBy(x=>x.MessageDate);
        }
    }
}
