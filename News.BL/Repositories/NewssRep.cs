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
    public class NewssRep : INewssRep
    {
        private readonly DemoContext db;

        public NewssRep(DemoContext _db)
        {
            db = _db;
        }

        public IEnumerable<Newss> Get()
        {

            var data = db.Newss.Include(a=>a.Categories).Select(a => a);
            return data;
           
        }


        public Newss GetById(int id)
        {
            var data = db.Newss.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }


        public void Create(Newss obj)
        {
            db.Newss.Add(obj);
            db.SaveChanges();
                
        }


        public void Update(Newss obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

        }


        public void Delete(Newss obj)
        {
            db.Newss.Remove(obj);
            db.SaveChanges();
        }

      
      
    }
}
