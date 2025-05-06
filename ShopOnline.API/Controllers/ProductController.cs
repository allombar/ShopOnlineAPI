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

        //[HttpGet]
        //public ActionResult<IEnumerable<ProductResponse>> GetAll()
        //{
        //    return Ok(_productService.GetAll());
        //}

        //[HttpGet("{id}")]
        //public ActionResult<ProductResponse> GetById(int id)
        //{
        //    var product = _productService.GetById(id);
        //    return product is null ? NotFound() : Ok(product);
        //}

        //[HttpGet("category/{categoryId}")]
        //public ActionResult<IEnumerable<ProductResponse>> GetByCategory(int categoryId)
        //{
        //    return Ok(_productService.GetByCategory(categoryId));
        //}

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create(ProductCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var id = _productService.Create(request.ToBll());

                return CreatedAtAction(null/*nameof(GetById)*/, new { id }, null);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // règle métier non respectée
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            //return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        //[HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Update(int id, ProductCreateRequest request)
        //{
        //    var result = _productService.Update(id, request);
        //    return result ? NoContent() : NotFound();
        //}

        //[HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Delete(int id)
        //{
        //    var result = _productService.Delete(id);
        //    return result ? NoContent() : NotFound();
        //}
    }

}
