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

        [HttpGet("{prodictId}")]
        public async Task<ActionResult<Product>> getProduct(int prodictId)
        {
            var product = await _repository.getProductsById(prodictId);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> addProduct(Product product)
        {
            var newProduct = await _repository.addProduct(product);
            return CreatedAtAction(nameof(getProduct), new { productId = newProduct.productId }, newProduct);
        }
        [HttpPost("{productId}")]
        public async Task<IActionResult> updateProduct(int productId, Product product)
        {
            if (productId != product.productId) return BadRequest();
            var updatedProduct = await _repository.updateProduct(product);
            return updatedProduct == null ? NotFound() : NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteStudent (int productId)
        {
            return await _repository.deleteProduct(productId)? NoContent() : NotFound();
        }
    }
}
