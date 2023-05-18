using RandomGame.BusinessLogicLayer.Abstract;
using RandomGame.Core.BLL.Logger;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.DTO;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.BusinessLogicLayer.Concrete
{
    public class GameManager : IGameService
    {
        IGameDAL game;
        
        
        public GameManager(IGameDAL gameDAL)
        {
            game = gameDAL;
        }
        public bool Add(Game entity)
        {
            try
            {
                
                bool result =  game.Add(entity);
                if (result)
                {
                    RandomGameLog.LogAdd(entity.Id + "Id değerine ve" + entity.GameName + "isim değerine sahip oyun eklendi!",LogType.Insert);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd(entity.GameName + "isim değerine sahip oyun eklenemedi!", LogType.NonValidation);
                    return false;
                }
            }
            catch (Exception ex)
            {
                RandomGameLog.LogAdd(entity.GameName + "isim değerine sahip oyun eklenemedi! Hata Mesajı: "+ex.Message, LogType.Error);
                return false;
            }
        }

        public bool Delete(Game entity)
        {
            try
            {
                bool result = game.Delete(entity);
                if (result)
                {
                    RandomGameLog.LogAdd(entity.Id + "Id değerine ve" + entity.GameName + "isim değerine sahip oyun silindi!", LogType.Delete);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd(entity.GameName + "isim değerine sahip oyun silinemedi!", LogType.NotFound);
                    return false;
                }
            }
            catch (Exception ex)
            {
                RandomGameLog.LogAdd(entity.GameName + "isim değerine sahip oyun silinemedi! Hata Mesajı: " + ex.Message, LogType.Error);
                return false;
            }
        }

        public IEnumerable<Game> Get()
        {
            try
            {
                var result = game.Get();
                return result;
            }
            catch (Exception ex)
            {
                RandomGameLog.LogAdd("Hata Mesajı: " + ex.Message, LogType.Error);
                return null;
            }
        }

        public Game Get(int id)
        {
            try
            {
                var result = game.Get(id);
                return result;
            }
            catch (Exception ex)
            {
                RandomGameLog.LogAdd("Hata Mesajı: " + ex.Message, LogType.Error);
                return null;
            }
        }

        public IEnumerable<GameDTO> GetGameAndImage()
        {
            try
            {
                var result = game.GetGameAndImage();
                return result;
            }
            catch (Exception ex)
            {
                RandomGameLog.LogAdd("Hata Mesajı: " + ex.Message, LogType.Error);
                return null;
            }
        }

        public GameDTO GetGameAndImageById(int gameId)
        {
            try
            {
                var result = game.GetGameAndImageById(gameId);
                return result;
            }
            catch (Exception ex)
            {
                RandomGameLog.LogAdd("Hata Mesajı: " + ex.Message, LogType.Error);
                return null;
            }
        }

        public bool Update(Game entity)
        {
            try
            {
                bool result = game.Update(entity);
                if (result)
                {
                    RandomGameLog.LogAdd(entity.Id + "Id değerine ve" + entity.GameName + "isim değerine sahip oyun güncellendi!", LogType.Update);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd(entity.GameName + "isim değerine sahip oyun güncellenemedi!", LogType.NonValidation);
                    return false;
                }
            }
            catch (Exception ex)
            {
                RandomGameLog.LogAdd("Hata Mesajı: " + ex.Message, LogType.Error);
                return false;
            }
        }
    }
}
