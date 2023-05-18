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
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL categoryDAL;
        public CategoryManager(ICategoryDAL category)
        {
            categoryDAL = category;
        }  
        public bool Add(Category entity)
        {
            try
            {
                bool result = categoryDAL.Add(entity);
                if (result)
                {
                    RandomGameLog.LogAdd($"{entity.CategoryName} isimli kategori eklendi!", LogType.Insert);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd($"{entity.CategoryName} isimli kategori eklenemedi!", LogType.NonValidation);
                    return false;
                }
            }
            catch (Exception e)
            {

                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return false;
            }
        }

        public bool Delete(Category entity)
        {
            try
            {
                bool result = categoryDAL.Delete(entity);
                if (result)
                {
                    RandomGameLog.LogAdd($"{entity.CategoryName} isimli kategori silindi!", LogType.Delete);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd($"{entity.CategoryName} isimli kategori silinemedi!", LogType.NotFound);
                    return false;
                }
            }
            catch (Exception e)
            {

                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return false;
            }
        }

        public IEnumerable<Category> Get()
        {
            try
            {
                var result = categoryDAL.Get();
                return result;
            }
            catch (Exception e)
            {

                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return null;
            }
        }

        public Category Get(int id)
        {
            try
            {
                var result = categoryDAL.Get(id);
                return result;
            }
            catch (Exception e)
            {

                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return null;
            }
        }

        public bool Update(Category entity)
        {
            try
            {
                bool result = categoryDAL.Update(entity);
                if (result)
                {
                    RandomGameLog.LogAdd($"{entity.CategoryName} isimli kategori güncellendi!", LogType.Update);
                    return true;
                }
                else
                {
                    RandomGameLog.LogAdd($"{entity.CategoryName} isimli kategori güncellenemedi!", LogType.NonValidation);
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
