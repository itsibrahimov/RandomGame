using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomGame.API.Models;
using RandomGame.BusinessLogicLayer.Abstract;

namespace RandomGame.API.Controllers
{
    //[Route("Oyun")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameService gameService;
        public GameController(IGameService game)
        {
            this.gameService = game;
        }
        [HttpGet]
        //[Route("Liste")]
        public IActionResult GetGames()
        {
            var result = gameService.GetGameAndImage();
            return Ok(result);
        }
        [HttpGet("{gameId}")]
        public IActionResult GetGameById(int gameId)
        {
            var result = gameService.GetGameAndImageById(gameId);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateGame(GameModel game)
        {
            var result = gameService.Update(game);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteGame(GameModel game)
        {
            var result = gameService.Delete(game);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddGame(GameModel game)
        {
            var result = gameService.Add(game);
            return Ok(result);
        }
    }
}
