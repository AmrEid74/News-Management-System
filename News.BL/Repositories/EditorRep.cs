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
    public class EditorRep : IEditorRep
    {
        private readonly DemoContext db;

        public EditorRep(DemoContext _db)
        {
            db = _db;
        }

        public IEnumerable<Editor> Get()
        {
            var data = db.Editor.Select(a => a);
            return data;
        }

        public Editor GetById(int id)
        {
           var data = db.Editor.Where(a=>a.Id == id).FirstOrDefault();
            return data;
        }



        public void Create(Editor obj)
        {
            db.Editor.Add(obj);
            db.SaveChanges();
        }

    
      
        public void Update(Editor obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(Editor obj)
        {
            db.Editor.Remove(obj);
            db.SaveChanges();
        }

    }
}
