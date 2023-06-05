using StorageAPI.Models;

namespace StorageAPI.Services
{
    public interface IStorageService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(uint id);
        Task<Product> CreateProductAsync(Product productToCreate);
        Task<Product> EditProductAsync(uint id, Product productToEdit);
    }
}
