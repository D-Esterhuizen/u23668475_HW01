using u23668475_HW01.Models;

namespace u23668475_HW01.Repositories
{
    public interface IproductRepository
    {
        Task<IEnumerable<Product>> getAllProducts();

        Task<Product?> getProductsById(int productID);

        Task<Product?> addProduct(Product product);
        Task<Product?> updateProduct(Product product);
        Task<bool> deleteProduct(int productID);

    }
}
