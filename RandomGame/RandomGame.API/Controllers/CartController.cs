using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomGame.API.Models;
using RandomGame.BusinessLogicLayer.Abstract;
using RandomGame.Entity.DTO;
using System;

namespace RandomGame.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        [HttpGet("{userId}/{gameId}")]
        public IActionResult DeleteCart(int userId,int gameId)
        {
            cartService.DeleteCartById(userId, gameId);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddCart([FromBody] CartDTO cartDTO)
        {
            decimal total = 0;
            var result = cartService.AddToCart(cartDTO);
            foreach (var item in result)
            {
                total += (item.Price) * (Convert.ToDecimal(item.Quantity));
            }
            return Ok(total);
        }
        [HttpPut]
        public IActionResult UpdateCart(CartModel cartModel)
        {
            var result = cartService.Update(cartModel);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetCarts()
        {
            var result = cartService.Get();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetCartById(int id)
        {
            var result = cartService.GetCartByUserId(id);
            return Ok(result);
        }
    }
}
