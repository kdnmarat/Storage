using Microsoft.EntityFrameworkCore;
using StorageAPI.Models;

namespace StorageAPI.Services
{
    public partial class StorageService : IStorageService
    {
        public async Task<List<StateOfStorage>> GetStatesOfStoragesAsync()
        {
            var statesOfStorages = await _dbContext.StatesOfStorages
                .Include(s => s.Product)
                .Include(s => s.Storage)
                .ToListAsync();
            return statesOfStorages;
        }

        public async Task<StateOfStorage> GetStateOfStorageAsync(uint id)
        {
            var stateOfStorage = await _dbContext.StatesOfStorages.Where(s => (s.Id == id))
                .Include(s => s.Product)
                .Include(s => s.Storage)
                .FirstOrDefaultAsync();
            return stateOfStorage;
        }

        public async Task<List<StateOfStorage>> GetStatesOfStoragesByStorageIdAsync(uint id)
        {
            var statesOfStorages = await _dbContext.StatesOfStorages.Where(s => (s.StorageId == id))
                .Include(s => s.Product)
                .Include(s => s.Storage)
                .ToListAsync();
            return statesOfStorages;
        }

        public async Task<List<StateOfStorage>> GetStatesOfStoragesByProductIdAsync(uint id)
        {
            var statesOfStorages = await _dbContext.StatesOfStorages.Where(s => (s.ProductId == id))
                .Include(s => s.Product)
                .Include(s => s.Storage)
                .ToListAsync();
            return statesOfStorages;
        }

        public async Task<StateOfStorage> FindProductOnStorageAsync(uint storageId, uint productId)
        {
            var stateOfStorage = await _dbContext.StatesOfStorages
                .Where(s => ((s.ProductId == productId) && ((s.StorageId == storageId))))
                .Include(s => s.Product)
                .Include(s => s.Storage)
                .SingleOrDefaultAsync();
            return stateOfStorage;
        }

        public async Task<StateOfStorage> CreateStateOfStorageAsync(StateOfStorage stateOfStorageToCreate)
        {
            var stateOfStorageFromDb = await _dbContext.StatesOfStorages.SingleOrDefaultAsync(s => s.Id == stateOfStorageToCreate.Id);
            var productFromDb = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == stateOfStorageToCreate.ProductId);
            var storageFromDb = await _dbContext.Storages.SingleOrDefaultAsync(s => s.Id == stateOfStorageToCreate.StorageId);
            var existing = await FindProductOnStorageAsync(stateOfStorageToCreate.StorageId, stateOfStorageToCreate.ProductId);
            if ((stateOfStorageFromDb != null) || (productFromDb == null) || (storageFromDb == null) || (existing != null))
            {
                return null;
            }

            var stateOfStorage = new StateOfStorage()
            {
                ProductId = productFromDb.Id,
                Product = productFromDb,
                StorageId = storageFromDb.Id,
                Storage = storageFromDb,
                Quantity = stateOfStorageToCreate.Quantity,
            };
            await _dbContext.StatesOfStorages.AddAsync(stateOfStorage);
            await _dbContext.SaveChangesAsync();
            return stateOfStorage;
        }

        public async Task<StateOfStorage> EditStateOfStorageAsync(uint id, StateOfStorage newStateOfStorageData)
        {
            var stateOfStorageFromDb = await _dbContext.StatesOfStorages.SingleOrDefaultAsync(p => p.Id == id);
            if (stateOfStorageFromDb == null)
            {
                return null;
            }
            stateOfStorageFromDb.Product = newStateOfStorageData.Product;
            stateOfStorageFromDb.Storage = newStateOfStorageData.Storage;
            stateOfStorageFromDb.Quantity = newStateOfStorageData.Quantity;

            await _dbContext.SaveChangesAsync();
            return stateOfStorageFromDb;
        }

        public async Task<StateOfStorage> DeleteStateOfStorageAsync(uint id)
        {
            var stateOfStorageFromDb = await _dbContext.StatesOfStorages.SingleOrDefaultAsync(p => p.Id == id);
            if (stateOfStorageFromDb == null)
            {
                return null;
            }
            _dbContext.StatesOfStorages.Remove(stateOfStorageFromDb);
            await _dbContext.SaveChangesAsync();
            return stateOfStorageFromDb;
        }


    }
}
