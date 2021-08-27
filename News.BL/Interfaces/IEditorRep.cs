using News.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Interfaces
{
    public interface IEditorRep
    {
        IEnumerable<Editor> Get();
        Editor GetById(int id);
        void Create(Editor obj);
        void Update(Editor obj);
        void Delete(Editor obj);
    }
}
