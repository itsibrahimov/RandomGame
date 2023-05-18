using RandomGame.BusinessLogicLayer.Abstract;
using RandomGame.Core.BLL.Logger;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.BusinessLogicLayer.Concrete
{
    public class GameCategoryManager : IGameCategoryService
    {
        IGameCategoryDAL gameCategoryDAL;
        public GameCategoryManager(IGameCategoryDAL gameCategoryDAL)
        {
            this.gameCategoryDAL = gameCategoryDAL;
        }

        public bool Add(GameCategory entity)
        {
            try
            {

                bool result = gameCategoryDAL.Add(entity);
                if (result)
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyun ve" + entity.CategoryID + "Id değerine sahip kategori eklendi!", LogType.Insert);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyun ve" + entity.CategoryID + "Id değerine sahip kategori eklenemedi!", LogType.NonValidation);
                    return false;
                }
            }
            catch (Exception ex)
            {
                RandomGameLog.LogAdd("Hata Mesajı: " + ex.Message, LogType.Error);
                return false;
            }
        }

        public bool Delete(GameCategory entity)
        {
            try
            {

                bool result = gameCategoryDAL.Delete(entity);
                if (result)
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyun ve" + entity.CategoryID + "Id değerine sahip kategori silindi!", LogType.Delete);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyun ve" + entity.CategoryID + "Id değerine sahip kategori silinemedi!", LogType.NotFound);
                    return false;
                }
            }
            catch (Exception ex)
            {
                RandomGameLog.LogAdd("Hata Mesajı: " + ex.Message, LogType.Error);
                return false;
            }
        }

        public IEnumerable<GameCategory> Get()
        {
            try
            {

                var result = gameCategoryDAL.Get();
                return result;
            }
            catch (Exception ex)
            {
                RandomGameLog.LogAdd("Hata Mesajı: " + ex.Message, LogType.Error);
                return null;
            }
        }

        public GameCategory Get(int id)
        {
            try
            {

                var result = gameCategoryDAL.Get(id);
                return result;
            }
            catch (Exception ex)
            {
                RandomGameLog.LogAdd("Hata Mesajı: " + ex.Message, LogType.Error);
                return null;
            }
        }

        public bool Update(GameCategory entity)
        {
            try
            {

                bool result = gameCategoryDAL.Update(entity);
                if (result)
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyun ve" + entity.CategoryID + "Id değerine sahip kategori güncellendi!", LogType.Update);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyun ve" + entity.CategoryID + "Id değerine sahip kategori güncellenemedi!", LogType.NonValidation);
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
