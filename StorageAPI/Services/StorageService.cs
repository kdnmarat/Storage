﻿using Microsoft.EntityFrameworkCore;
using StorageAPI.Models;
using StorageAPI.Models.DbContexts;

namespace StorageAPI.Services
{
    public class StorageService : IStorageService
    {
        private readonly AppDbContext _dbContext;
        public StorageService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _dbContext.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductAsync(uint id)
        {
            var product = await _dbContext.Products.Where(p => (p.Id == id)).FirstAsync();
            return product;
        }

        public async Task<Product> CreateProductAsync(Product productToCreate)
        {
            var productFromDb = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == productToCreate.Id);

            if (productFromDb != null)
            {
                productFromDb.Name = productToCreate.Name;
                productFromDb.Cost = productToCreate.Cost;

                await _dbContext.SaveChangesAsync();

                return productFromDb;
            }
            else
            {
                var product = new Product()
                {
                    Name = productToCreate.Name,
                    Cost = productToCreate.Cost,
                };
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return product;
            }
        }

    }
}
