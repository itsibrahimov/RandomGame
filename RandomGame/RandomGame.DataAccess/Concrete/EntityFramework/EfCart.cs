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
    public class EfCart:EfRepository<Cart,RandomGameDbContext>,ICartDAL
    {
        private readonly RandomGameDbContext db;
        public EfCart(RandomGameDbContext dbContext):base(dbContext)
        {
            db = dbContext;
        }

        public IEnumerable<CartDTO> AddToCart(CartDTO cartDTO)
        {
            var result = db.Cart.FirstOrDefault(x => x.AppUserId == cartDTO.UserId && x.GameID == cartDTO.GameId);
            if (result==null)
            {
                db.Cart.Add(new Cart { GameID = cartDTO.GameId, AppUserId = cartDTO.UserId, Quantity = cartDTO.Quantity });
                db.SaveChanges();
            }
            else
            {
                result.Quantity= result.Quantity+1;
                db.Cart.Update(result);
                db.SaveChanges();
            }

            var carts =
                from crt in db.Cart
                join gm in db.Game
                on crt.GameID equals gm.Id
                join apUser in db.Users
                on crt.AppUserId equals apUser.Id
                where crt.AppUserId == cartDTO.UserId
                select new CartDTO
                {
                    Quantity = crt.Quantity,
                    UserId = apUser.Id,
                    GameId = gm.Id,
                    GameName = gm.GameName,
                    ImageURl = db.Image.FirstOrDefault(x=>x.GameID==gm.Id).ImageURL,
                    Price = gm.Price,
                    Active = crt.Active,
                    Deleted = crt.Deleted

                };
            return carts.ToList();

        }

        public void DeleteCartById(int userId, int gameId)
        {
            var result = db.Cart.FirstOrDefault(c => c.GameID == gameId && c.AppUserId == userId);
            if (result!=null)
            {
                db.Cart.Remove(result);
                db.SaveChanges();
            }
        }

        public IEnumerable<CartDTO> GetCartByUserId(int userId)
        {
            var carts =
                from crt in db.Cart
                join gm in db.Game
                on crt.GameID equals gm.Id
                join apUser in db.Users
                on crt.AppUserId equals apUser.Id
                where crt.AppUserId == userId && crt.Active==true && crt.Deleted==false
                select new CartDTO
                {
                    Quantity = crt.Quantity,
                    UserId = apUser.Id,
                    GameId = gm.Id,
                    GameName = gm.GameName,
                    ImageURl = db.Image.FirstOrDefault(x => x.GameID == gm.Id).ImageURL,
                    Price = gm.Price,
                    Active = crt.Active,
                    Deleted = crt.Deleted

                };
            return carts.ToList();
        }
    }
}
