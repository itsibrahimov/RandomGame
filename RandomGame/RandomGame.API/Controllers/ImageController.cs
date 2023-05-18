using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomGame.API.Models;
using RandomGame.BusinessLogicLayer.Abstract;

namespace RandomGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IImageService ımageService;
        public ImageController(IImageService ımageService)
        {
            this.ımageService = ımageService;
        }
        [HttpDelete]
        public IActionResult DeleteImage(ImageModel imageModel)
        {
            var result = ımageService.Delete(imageModel);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddImage(ImageModel imageModel)
        {
            var result = ımageService.Add(imageModel);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateImage(ImageModel imageModel)
        {
            var result = ımageService.Update(imageModel);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetImages()
        {
            var result = ımageService.Get();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetImageById(int id)
        {
            var result = ımageService.Get(id);
            return Ok(result);
        }
    }
}
