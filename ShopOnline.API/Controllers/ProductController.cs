using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Mappers;
using ShopOnline.API.Models.Product;
using ShopOnline.BLL.interfaces;

namespace ShopOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll().Select(p => p.ToDto());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _productService.GetById(id).ToDto();
                return Ok(product);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetByCategory(int categoryId)
        {
            var products = _productService.GetByCategoryId(categoryId).Select(p => p.ToDto());
            return Ok(products);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create([FromBody] ProductRequest dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _productService.Create(dto.ToBll());
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductRequest dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _productService.Update(id, dto.ToBll());
                return CreatedAtAction(nameof(Get), new { id }, null);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}