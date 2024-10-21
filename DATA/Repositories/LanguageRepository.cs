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
    public class LanguageRepository:GenericRepository<Languages>,ILanguageDAL
    {
        private readonly GoldElectronicsDb _db;
        public LanguageRepository(GoldElectronicsDb db):base(db)
        {
            _db = db;
        }
      

            public string GetResource(string culture, string key)
            {
                var resource =  _db.Localizations
                    .FirstOrDefault(r => r.Culture == culture && r.ResourceKey == key);

                return resource?.ResourceValue ?? string.Empty;
            }
       

    }
}
