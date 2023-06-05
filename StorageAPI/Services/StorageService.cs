using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using StorageAPI.Models;
using StorageAPI.Models.DbContexts;
using System.Net;

namespace StorageAPI.Services
{
    public partial class StorageService : IStorageService
    {
        private readonly AppDbContext _dbContext;
        public StorageService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Product, Storage and StateOfStorage CRUD functions are in "StorageService" folder
    }
}
