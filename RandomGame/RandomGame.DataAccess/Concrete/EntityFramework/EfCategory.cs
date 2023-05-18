using RandomGame.DataAccess.Abstract;
using RandomGame.DataAccess.Context;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.DataAccess.Concrete.EntityFramework
{
    public class EfCategory:EfRepository<Category,RandomGameDbContext>,ICategoryDAL
    {
        private RandomGameDbContext _db;
        public EfCategory(RandomGameDbContext db):base(db)
        {
            _db = db;
        }
    }
}
