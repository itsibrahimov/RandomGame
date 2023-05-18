using RandomGame.Core.BLL;
using RandomGame.Entity.DTO;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.BusinessLogicLayer.Abstract
{
    public interface ICartService:IGenericService<Cart>
    {
        IEnumerable<CartDTO> AddToCart(CartDTO cartDTO);
        IEnumerable<CartDTO> GetCartByUserId(int userId);
        void DeleteCartById(int userId, int gameId);
    }
}
