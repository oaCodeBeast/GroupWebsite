using System;
using LinqKit;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GroupWebsiteRestart.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {

        private GroupProjectEntities1 db = new GroupProjectEntities1();


        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity FindByID(Guid? id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            db.SaveChanges();
        }

        //This search requires the use of LINQkit which can be installed via NuGet
        //ADD using Linqkit; AND using System.Linq.Expressions;
        public IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            //We need to add the .AsExpandable() to our call in order to avoid 
            //the error "LINQ expression node type 'Invoke' is not supported in LINQ to
            //Entities."
            IQueryable<TEntity> query = db.Set<TEntity>().AsExpandable().Where(predicate);
            return query;
        }


        /* The Dispose() is used to clean up anything that this object has
            opened before the object is destroyed and removed from memory
            such as database connections or file streams. */
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }

            this.disposed = true;
        }

    }//end class
}//end namespace