using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RandomGame.BusinessLogicLayer.Abstract;
using RandomGame.Entity.DTO;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace RandomGame.MVC.Controllers
{
    public class CartController : Controller
    {
        UserManager<AppUser> userManager;
        ICartService cartService;
        public CartController(UserManager<AppUser> userManager, ICartService cartService)
        {
            this.userManager = userManager;
            this.cartService = cartService;
        }
    
        public IActionResult Index()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name);
            HttpClient client = new HttpClient();
            string apiUrl = "https://localhost:44362/api/Cart/GetCartById/" + user.Result.Id;
            //Uri uri = new Uri(apiUrl);
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            string sonuc = webClient.DownloadString(apiUrl);
            List<CartDTO> result = JsonConvert.DeserializeObject<List<CartDTO>>(sonuc);
            return View(result);
        }
        
        public IActionResult AddToCart(int gameId,int count)
        {
            var user = userManager.FindByNameAsync(User.Identity.Name);
            var cart = new CartDTO { UserId = user.Result.Id, GameId = gameId, Quantity = count };
            string apiUrl = "https://localhost:44362/api/Cart/AddCart";
            HttpClient client = new HttpClient();
            var result = JsonConvert.SerializeObject(cart);
            StringContent content = new StringContent(result, System.Text.Encoding.UTF8, "application/json");
            var sonuc = client.PostAsync(apiUrl, content);
            var rst = sonuc.Result.Content.ReadAsStringAsync();
            return Ok(rst.Result);
            
        }

        public IActionResult DeleteCartByID(int gameId)
        {
            var user = userManager.FindByNameAsync(User.Identity.Name);
            HttpClient client = new HttpClient();
            string apiUrl = "https://localhost:44362/api/Cart/DeleteCart/" + user.Result.Id+"/"+gameId;
            //Uri uri = new Uri(apiUrl);
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            string sonuc = webClient.DownloadString(apiUrl);
            return RedirectToAction("Index");
        }

    }
}
