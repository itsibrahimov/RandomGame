using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RandomGame.MVC.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace RandomGame.MVC.Controllers
{
	public class GameController : Controller
	{
		public IActionResult Detail(int gameId)
		{
            HttpClient client = new HttpClient();
            string apiUrl = "https://localhost:44362/Game/GetGameById/"+gameId;
            //Uri uri = new Uri(apiUrl);
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            string sonuc = webClient.DownloadString(apiUrl);
            GameModel result = JsonConvert.DeserializeObject<GameModel>(sonuc);
            return View(result);
		}
	}
}
