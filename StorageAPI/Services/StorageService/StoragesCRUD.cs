using Microsoft.EntityFrameworkCore;

namespace StorageAPI.Services
{
    public partial class StorageService : IStorageService
    {
        public async Task<List<Models.Storage>> GetStoragesAsync()
        {
            var storages = await _dbContext.Storages.ToListAsync();
            return storages;
        }

        public async Task<Models.Storage> GetStorageAsync(uint id)
        {
            var storage = await _dbContext.Storages.Where(s => (s.Id == id)).FirstOrDefaultAsync();
            return storage;
        }

        public async Task<Models.Storage> CreateStorageAsync(Models.Storage storageToCreate)
        {
            var storageFromDb = await _dbContext.Storages.SingleOrDefaultAsync(s => s.Id == storageToCreate.Id);
            if (storageFromDb != null)
            {
                return null;
            }

            var storage = new Models.Storage()
            {
                Name = storageToCreate.Name,
                KindOfStorage = storageToCreate.KindOfStorage,
                Address = storageToCreate.Address,
            };
            await _dbContext.Storages.AddAsync(storage);
            await _dbContext.SaveChangesAsync();
            return storage;
        }

        public async Task<Models.Storage> EditStorageAsync(uint id, Models.Storage newStorageData)
        {
            var storageFromDb = await _dbContext.Storages.SingleOrDefaultAsync(s => s.Id == id);
            if (storageFromDb == null)
            {
                return null;
            }
            storageFromDb.Name = newStorageData.Name;
            storageFromDb.KindOfStorage = newStorageData.KindOfStorage;
            storageFromDb.Address = newStorageData.Address;

            await _dbContext.SaveChangesAsync();
            return storageFromDb;
        }

        public async Task<Models.Storage> DeleteStorageAsync(uint id)
        {
            var storageFromDb = await _dbContext.Storages.SingleOrDefaultAsync(p => p.Id == id);
            if (storageFromDb == null)
            {
                return null;
            }
            _dbContext.Storages.Remove(storageFromDb);
            await _dbContext.SaveChangesAsync();
            return storageFromDb;
        }
    }
}
