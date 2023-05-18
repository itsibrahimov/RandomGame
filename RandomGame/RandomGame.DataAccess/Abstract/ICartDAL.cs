using RandomGame.Core.DAL;
using RandomGame.Entity.DTO;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.DataAccess.Abstract
{
    public interface ICartDAL:IRepository<Cart>
    {
        IEnumerable<CartDTO> AddToCart(CartDTO cartDTO);
        IEnumerable<CartDTO> GetCartByUserId(int userId);
        void DeleteCartById(int userId, int gameId);
    }
}
