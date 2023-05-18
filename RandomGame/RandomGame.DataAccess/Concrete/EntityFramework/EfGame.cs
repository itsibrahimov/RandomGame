using Microsoft.Extensions.Primitives;
using RandomGame.DataAccess.Abstract;
using RandomGame.DataAccess.Context;
using RandomGame.Entity.DTO;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGame.DataAccess.Concrete.EntityFramework
{
    
    public class EfGame : EfRepository<Game, RandomGameDbContext>, IGameDAL
    {
        private readonly RandomGameDbContext _context;

        public EfGame(RandomGameDbContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<GameDTO> GetGameAndImage()
        {
            var games =
                 from game in db.Game
                 where game.Active == true && game.Deleted == false
                 select new GameDTO
                 {
                     GameID=game.Id,
                     GameName = game.GameName,
                     Price = game.Price,
                     Description = game.Description,
                     Stock = game.Stock,
                     Images = db.Image.Where(x => x.GameID == game.Id).ToList()
                 };
            return games;
        }

        public GameDTO GetGameAndImageById(int gameId)
        {
            var games =
                  from game in db.Game
                  where game.Id==gameId && game.Active == true && game.Deleted == false
                  select new GameDTO
                  {
                      GameID = game.Id,
                      GameName = game.GameName,
                      Price = game.Price,
                      Description = game.Description,
                      Stock = game.Stock,
                      Images = db.Image.Where(x => x.GameID == game.Id).ToList()
                  };
            return games.FirstOrDefault();
        }
    }
}
