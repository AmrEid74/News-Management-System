using News.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Interfaces
{
  public  interface INewssRep
    {
        IEnumerable<Newss> Get();
        Newss GetById(int id);
        void Create(Newss obj);
        void Update(Newss obj);
        void Delete(Newss obj);
    }
}
