using StorageAPI.Models;

namespace StorageAPI.Services
{
    public interface IStorageService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(uint id);
        Task<Product> CreateProductAsync(Product productToCreate);
        Task<Product> EditProductAsync(uint id, Product newProductData);
        Task<Product> DeleteProductAsync(uint id);

        Task<List<Storage>> GetStoragesAsync();
        Task<Storage> GetStorageAsync(uint id);
        Task<Storage> CreateStorageAsync(Storage storageToCreate);
        Task<Storage> EditStorageAsync(uint id, Storage newStorageData);
        Task<Storage> DeleteStorageAsync(uint id);

        Task<List<StateOfStorage>> GetStatesOfStoragesAsync();
        Task<StateOfStorage> GetStateOfStorageAsync(uint id);
        Task<StateOfStorage> CreateStateOfStorageAsync(StateOfStorage stateOfStorageToCreate);
        Task<StateOfStorage> EditStateOfStorageAsync(uint id, StateOfStorage newStateOfStorageData);
        Task<StateOfStorage> DeleteStateOfStorageAsync(uint id);
        Task<List<StateOfStorage>> GetStatesOfStoragesByStorageIdAsync(uint id);
        Task<List<StateOfStorage>> GetStatesOfStoragesByProductIdAsync(uint id);
    }
}
