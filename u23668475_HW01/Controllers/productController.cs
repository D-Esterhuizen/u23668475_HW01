using Microsoft.AspNetCore.Mvc;
using u23668475_HW01.Models;
using u23668475_HW01.Repositories;

namespace u23668475_HW01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly IproductRepository _repository;

        public productController(IproductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> getAllProducts()
        {
            return Ok(await _repository.getAllProducts());
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> getProduct(int productId)
        {
            var product = await _repository.getProductsById(productId);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> addProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newProduct = await _repository.addProduct(product);
                if (newProduct == null)
                {
                    return StatusCode(500, "A problem happened while handling your request. NULL");
                }
                return CreatedAtAction(nameof(getProduct), new { productId = newProduct.productId }, newProduct);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, Product product)
        {
            if (productId != product.productId) return BadRequest();
            var updatedProduct = await _repository.UpdateProduct(product);
            return updatedProduct == null ? NotFound() : NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> deleteProduct(int productId)
        {
            return await _repository.deleteProduct(productId) ? NoContent() : NotFound();
        }
    }
}
