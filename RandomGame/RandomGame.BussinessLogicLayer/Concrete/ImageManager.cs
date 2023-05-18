using RandomGame.BusinessLogicLayer.Abstract;
using RandomGame.Core.BLL.Logger;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RandomGame.BusinessLogicLayer.Concrete
{
    public class ImageManager : IImageService
    {
        IimageDAL ıimageDAL;
        public ImageManager(IimageDAL ıimageDAL)
        {
            this.ıimageDAL = ıimageDAL;
        }

        public bool Add(Image entity)
        {
            try
            {

                bool result = ıimageDAL.Add(entity);
                if (result)
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyuna fotograf eklendi!", LogType.Insert);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyuna fotograf eklendi!", LogType.NonValidation);
                    return false;
                }
            }
            catch (Exception e)
            {
                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return false;
            }
        }

        public bool Delete(Image entity)
        {
            try
            {

                bool result = ıimageDAL.Delete(entity);
                if (result)
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyuna fotograf silindi!", LogType.Delete);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyuna fotograf silinemedi!", LogType.NotFound);
                    return false;
                }
            }
            catch (Exception e)
            {
                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return false;
            }
        }

        public IEnumerable<Image> Get()
        {
            try
            {

                var result = ıimageDAL.Get();
                return result;
            }
            catch (Exception e)
            {
                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return null;
            }
        }

        public Image Get(int id)
        {
            try
            {

                var result = ıimageDAL.Get(id);
                return result;
            }
            catch (Exception e)
            {
                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return null;
            }
        }

        public bool Update(Image entity)
        {
            try
            {

                bool result = ıimageDAL.Update(entity);
                if (result)
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyunadaki fotograf güncellendi!", LogType.Update);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd(entity.GameID + "Id değerine sahip oyuna fotograf güncellenemedi!", LogType.NonValidation);
                    return false;
                }
            }
            catch (Exception e)
            {
                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return false;
            }
        }
    }
}
