using Microsoft.EntityFrameworkCore;
using StorageAPI.Models;

namespace StorageAPI.Services
{
    public partial class StorageService : IStorageService
    {
        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _dbContext.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductAsync(uint id)
        {
            var product = await _dbContext.Products.Where(p => (p.Id == id)).FirstOrDefaultAsync();
            return product;
        }

        public async Task<Product> CreateProductAsync(Product productToCreate)
        {
            var productFromDb = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == productToCreate.Id);
            if (productFromDb != null)
            {
                return null;
            }

            var product = new Product()
            {
                Name = productToCreate.Name,
                Cost = productToCreate.Cost,
            };
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> EditProductAsync(uint id, Product newProductData)
        {
            var productFromDb = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (productFromDb == null)
            {
                return null;
            }
            productFromDb.Name = newProductData.Name;
            productFromDb.Cost = newProductData.Cost;

            await _dbContext.SaveChangesAsync();
            return productFromDb;
        }

        public async Task<Product> DeleteProductAsync(uint id)
        {
            var productFromDb = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (productFromDb == null)
            {
                return null;
            }
            _dbContext.Products.Remove(productFromDb);
            await _dbContext.SaveChangesAsync();
            return productFromDb;
        }
    }
}
