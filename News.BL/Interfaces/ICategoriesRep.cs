using News.BL.Models;
using News.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Interfaces
{
  public  interface ICategoriesRep
    {
        IEnumerable<Categories> Get();
        Categories GetById(int id);
        void Create(Categories obj);
        void Update(Categories obj);
        void Delete(Categories obj);
    }
}
