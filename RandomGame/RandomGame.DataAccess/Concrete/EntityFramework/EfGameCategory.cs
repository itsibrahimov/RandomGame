using RandomGame.DataAccess.Abstract;
using RandomGame.DataAccess.Context;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.DataAccess.Concrete.EntityFramework
{
    public class EfGameCategory:EfRepository<GameCategory,RandomGameDbContext>,IGameCategoryDAL
    {
        private readonly RandomGameDbContext context;
        public EfGameCategory(RandomGameDbContext dbContext):base(dbContext)
        {
            context = dbContext;
        }
    }
}
