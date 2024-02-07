using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSArticle.ModelsLayer.Context;
using CMSArticle.ModelsLayer;
using System.Data.Entity;

namespace CMSArticle.RepositoryLayer
{
    public class GenericRepository<T> : IGenericRepository<T>where T : BaseEntity
    {

        CMSContext db;
        DbSet<T> DbContext;

        public GenericRepository(CMSContext context)
        {
            db = context;
            DbContext =context.Set<T>();    
        }


        public IEnumerable<T> GetAll()
        {
           return DbContext.ToList();
        }

        public T GetEntity(int id)
        {
            return DbContext.Find(id);
        }

        public bool Add(T Entity)
        {
            try
            {
                DbContext.Add(Entity);
                return true;

            }
            catch (Exception)
            {
                return false; 
            }
        }

        public bool Update(T Entity)
        {
            try
            {
               db.Entry(Entity).State = EntityState.Modified;
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T Entity)
        {
            try
            {
                db.Entry(Entity).State = EntityState.Deleted;
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                T entity = GetEntity(id);
                db.Entry(entity).State = EntityState.Deleted;
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }


        public void Dispose()
        {
           db.Dispose();
        }

  

  
    }
}
