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
    public class CartManager : ICartService
    {
        ICartDAL dAL;
        public CartManager(ICartDAL dAL)
        {
            this.dAL = dAL;
        }
        public bool Add(Cart entity)
        {
            try
            {
                bool result = dAL.Add(entity);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return false;
            }
        }

        public IEnumerable<CartDTO> AddToCart(CartDTO cartDTO)
        {
            try
            {
                var result = dAL.AddToCart(cartDTO);
                return result;
            }
            catch (Exception e)
            {

                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return null;
            }
        }

        public bool Delete(Cart entity)
        {
            try
            {
                bool result = dAL.Delete(entity);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return false;
            }
        }

        public void DeleteCartById(int userId, int gameId)
        {
            try
            {
                dAL.DeleteCartById(userId, gameId);
            }
            catch (Exception e)
            {
                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
            }
        }

        public IEnumerable<Cart> Get()
        {
            try
            {
                var result = dAL.Get();
                return result;
            }
            catch (Exception e)
            {

                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return null;
            }
        }

        public Cart Get(int id)
        {
            try
            {
                var result = dAL.Get(id);
                return result;
            }
            catch (Exception e)
            {

                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return null;
            }
        }

        public IEnumerable<CartDTO> GetCartByUserId(int userId)
        {
            try
            {
                var result = dAL.GetCartByUserId(userId);
                return result;
            }
            catch (Exception e)
            {
                RandomGameLog.LogAdd($"Hata: {e.Message}", LogType.Error);
                return null;
            }
        }

        public bool Update(Cart entity)
        {
            try
            {
                bool result = dAL.Update(entity);
                if (result)
                {
                    return true;
                }
                else
                {
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
