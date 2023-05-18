using RandomGame.Core.DAL;
using RandomGame.Entity.DTO;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.DataAccess.Abstract
{
    public interface IGameDAL:IRepository<Game>
    {
        IEnumerable<GameDTO> GetGameAndImage();
        GameDTO GetGameAndImageById(int gameId);
    }
}
