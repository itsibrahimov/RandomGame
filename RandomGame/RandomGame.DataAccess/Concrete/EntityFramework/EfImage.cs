using RandomGame.DataAccess.Abstract;
using RandomGame.DataAccess.Context;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.DataAccess.Concrete.EntityFramework
{
    public class EfImage:EfRepository<Image,RandomGameDbContext>,IimageDAL
    {
        private readonly RandomGameDbContext _context;
        public EfImage(RandomGameDbContext dbContext):base(dbContext)
        {
            _context= dbContext;
        }
    }
}
