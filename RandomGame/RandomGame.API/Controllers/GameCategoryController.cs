using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomGame.API.Models;
using RandomGame.BusinessLogicLayer.Abstract;

namespace RandomGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameCategoryController : ControllerBase
    {
        IGameCategoryService gmService;
        public GameCategoryController(IGameCategoryService gmService)
        {
            this.gmService = gmService;
        }
        [HttpDelete]
        public IActionResult DeleteGameCategory(GameCategoryModel gmModel)
        {
            var result = gmService.Delete(gmModel);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddGameCategory(GameCategoryModel gmModel)
        {
            var result = gmService.Add(gmModel);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateGameCategory(GameCategoryModel gmModel)
        {
            var result = gmService.Update(gmModel);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetGameCategories()
        {
            var result = gmService.Get();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetGameCategoryById(int id)
        {
            var result = gmService.Get(id);
            return Ok(result);
        }
    }
}
