using News.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Interfaces
{
   public interface IAdminRep
    {

        IEnumerable<Admin> Get();
        Admin GetById(int id);
        void Create(Admin obj);
        void Update(Admin obj);
        void Delete(Admin obj);

    }
}
