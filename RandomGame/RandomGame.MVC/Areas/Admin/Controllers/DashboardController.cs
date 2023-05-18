using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using RandomGame.Entity.DTO;

namespace RandomGame.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string apiUrl = "https://localhost:44362/Game/GetGames";
            //Uri uri = new Uri(apiUrl);
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            string sonuc = webClient.DownloadString(apiUrl);
            List<GameDTO> result = JsonConvert.DeserializeObject<List<GameDTO>>(sonuc);

            return View(result);
        }
    }
}
