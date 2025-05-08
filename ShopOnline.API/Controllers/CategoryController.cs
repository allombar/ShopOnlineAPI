
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Mappers;
using ShopOnline.API.Models.Category;
using ShopOnline.BLL.interfaces;
using ShopOnline.BLL.Mappers;
using ShopOnline.BLL.Models;
using ShopOnline.BLL.Services;
using ShopOnline.DAL.Entities;

namespace ShopOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService service)
        {
            _categoryService = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<CategoryEntity> entities = _categoryService.GetAll(); 
            List<CategoryRequest> result = new List<CategoryRequest>();

            foreach (var entity in entities)
            {
                result.Add(entity.ToDto());
            }

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category categoryModel;
            try
            {
                categoryModel = _categoryService.GetById(id);
                if (categoryModel == null)
                    return NotFound();

                CategoryRequest categoryRequest = categoryModel.ToDto();
                return Ok(categoryRequest);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create([FromBody] CategoryPost dto)
        {
            _categoryService.Create(dto.ToBll());
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CategoryPost dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _categoryService.Update(id, dto.ToBll());
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);    
            return NoContent();
        }
    }
}
