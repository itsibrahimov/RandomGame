using RandomGame.Core.BLL;
using RandomGame.Entity.DTO;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.BusinessLogicLayer.Abstract
{
    public interface IGameService:IGenericService<Game>
    {
        IEnumerable<GameDTO> GetGameAndImage();
        GameDTO GetGameAndImageById(int gameId);
    }
}
