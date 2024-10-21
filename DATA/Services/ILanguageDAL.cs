using Data.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ILanguageDAL:IGenericDAL<Languages>
    {
         string GetResource(string culture, string key);
        
    }
}
