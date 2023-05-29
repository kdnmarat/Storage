using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace StorageAPI.Models.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<StateOfStorage> StatesOfStorages { get; set; }
    }
}
