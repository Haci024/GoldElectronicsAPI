using Data.Connection;
using Data.Services;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ColorListRepository:GenericRepository<ColorList>,IColorListDAL
    {
        private readonly GoldElectronicsDb _db;
        public ColorListRepository(GoldElectronicsDb db):base(db)
        {
            _db = db;
        }

    }
}
