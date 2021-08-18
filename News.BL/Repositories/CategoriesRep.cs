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
    public class CategoriesRep : ICategoriesRep
    {
        private readonly DemoContext db;

        public CategoriesRep(DemoContext _db)
        {
            db = _db;
        }
        public IEnumerable<Categories> Get()
        {
            var data = db.Categories.Select(a=>a);
            return data;
        }



        public Categories GetById(int id)
        {
            var data = db.Categories.Where(a => a.Id == id).FirstOrDefault();
            return data;    

        }

        public void Create(Categories obj)
        {
             db.Categories.Add(obj);
            db.SaveChanges();
        }

        

        public void Update(Categories obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
                }
        public void Delete(Categories obj)
        {
             db.Categories.Remove(obj);
            db.SaveChanges();
        }
    }
}
