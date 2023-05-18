using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomGame.API.Models;
using RandomGame.BusinessLogicLayer.Abstract;

namespace RandomGame.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Route("Kategori")]
    public class CategoryController : ControllerBase
    {
        ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpDelete]
        public IActionResult DeleteCategory(CategoryModel category)
        {
            var result = categoryService.Delete(category);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryModel category)
        {
            var result = categoryService.Add(category);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateCategory(CategoryModel category)
        {
            var result = categoryService.Update(category);
            return Ok(result);
        }
        [HttpGet]
        [Route("KategoriListe")]
        public IActionResult GetCategories()
        {
            var result = categoryService.Get();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var result = categoryService.Get(id);
            return Ok(result);
        }
    }
}
