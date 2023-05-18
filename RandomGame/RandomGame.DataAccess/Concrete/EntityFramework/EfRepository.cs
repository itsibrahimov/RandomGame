using Microsoft.EntityFrameworkCore;
using RandomGame.Core.DAL;
using RandomGame.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.DataAccess.Concrete.EntityFramework
{
    public class EfRepository<TEntity, TDbcontext> : IRepository<TEntity> where TEntity : class, IBaseEntity, new()
        where TDbcontext : DbContext
    {
        public readonly TDbcontext db;
        public EfRepository(TDbcontext db)
        {
            this.db = db;
        }

        public bool Add(TEntity entity)
        {
            db.Add(entity);
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(TEntity entity)
        {
            
            db.Update(entity);
            return db.SaveChanges() > 0 ? true : false;
        }

        public IEnumerable<TEntity> Get()
        {
           return db.Set<TEntity>();
            
        }
        
        public TEntity Get(int id)
        {
           return db.Set<TEntity>().Find(id);
        }

        public bool Update(TEntity entity)
        {
            db.Update(entity);
            return db.SaveChanges()>0 ? true : false;
            
        }
    }
}
