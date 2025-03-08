using Microsoft.EntityFrameworkCore;
using u23668475_HW01.Data;
using u23668475_HW01.Models;


namespace u23668475_HW01.Repositories
{
    public class productRepository : IproductRepository
    {
        private readonly ApplicationDbContext _context;

        public productRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> getAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> getProductsById(int productID)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.productId == productID);
        }

        public async Task<Product> addProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }



        public async Task<Product?> updateProduct(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.productId);
            if (existingProduct == null) return null;

            existingProduct.productName = product.productName;
            existingProduct.productDescription = product.productDescription;
            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> deleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if(product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
