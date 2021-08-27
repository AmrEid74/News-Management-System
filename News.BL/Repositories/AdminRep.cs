using Microsoft.EntityFrameworkCore;
using News.BL.Interfaces;
using News.DAL.Database;
using News.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Repositories
{
    public class AdminRep : IAdminRep
    {
        private readonly DemoContext db;

        public AdminRep(DemoContext _db)
        {
            db = _db;
        }


        public IEnumerable<Admin> Get()
        {

            var data = db.Admin.Select(a => a);
            return data;

        }

        public Admin GetById(int id)
        {
            var data = db.Admin.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }


        public void Create(Admin obj)
        {
            db.Admin.Add(obj);
            db.SaveChanges();
        }



        public void Update(Admin obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Admin obj)
        {
            db.Admin.Remove(obj);
            db.SaveChanges();
        }

      

      
    }
}
