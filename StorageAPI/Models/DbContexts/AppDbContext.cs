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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Apple",
                    Cost = (decimal)7.8
                },
                new Product
                {
                    Id = 2,
                    Name = "Banana",
                    Cost = (decimal)12
                },
                new Product
                {
                    Id = 3,
                    Name = "Orange",
                    Cost = (decimal)8.5
                },
                new Product
                {
                    Id = 4,
                    Name = "Brocoli",
                    Cost = (decimal)10
                }
            );
            modelBuilder.Entity<Storage>().HasData(
                new Storage
                {
                    Id = 1,
                    Name = "Storage1",
                    KindOfStorage = "Fruits",
                    Address = "Somewhere in Belgrade"
                },
                new Storage
                {
                    Id = 2,
                    Name = "Storage2",
                    KindOfStorage = "Vegetables",
                    Address = "Somewhere else in Belgrade"
                }
            );
            modelBuilder.Entity<StateOfStorage>().HasData(
                new StateOfStorage
                {
                    Id = 1,
                    ProductId = 1,
                    StorageId = 1,
                    Quantity = 20
                },
                new StateOfStorage
                {
                    Id = 2,
                    ProductId = 2,
                    StorageId = 1,
                    Quantity = 2
                },
                new StateOfStorage
                {
                    Id = 3,
                    ProductId = 3,
                    StorageId = 1,
                    Quantity = 4
                },
                new StateOfStorage
                {
                    Id = 4,
                    ProductId = 4,
                    StorageId = 2,
                    Quantity = 8
                }
            );
        }
    }
}
