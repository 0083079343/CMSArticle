using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSArticle.RepositoryLayer
{
    public interface IGenericRepository<T>:IDisposable
    {
        //CRUD
        //R==> 1.All    2.One
        //C==>Create
        //U==>Update
        //D==>Delete
        IEnumerable<T> GetAll();
        T GetEntity(int id);
        bool Add(T Entity);
        bool Update(T Entity);
        bool Delete(T Entity);
        bool Delete(int id);
        void Save();

    }
}
