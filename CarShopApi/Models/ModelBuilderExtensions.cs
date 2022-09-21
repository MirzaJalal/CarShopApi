using CarShopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShopApi.API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Jeep" },
                new Category { Id = 2, Name = "Hatchback" },
                new Category { Id = 3, Name = "Sports Car" },
                new Category { Id = 4, Name = "Coupe" },
                new Category { Id = 5, Name = "Convertible" });

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, CategoryId = 1, Name = "BMW", ModelSku = "AWMGSJ", Price = 60008, IsAvailable = true },
                new Vehicle { Id = 2, CategoryId = 1, Name = "Tesla", ModelSku = "AWMPS", Price = 42535, IsAvailable = true },
                new Vehicle { Id = 3, CategoryId = 1, Name = "Audi", ModelSku = "AWMSGT", Price = 45364533, IsAvailable = true },
                new Vehicle { Id = 4, CategoryId = 1, Name = "Mercedes", ModelSku = "AWMSJ", Price = 254125, IsAvailable = true },
                new Vehicle { Id = 5, CategoryId = 1, Name = "BMW", ModelSku = "AWMTFJ", Price = 245260, IsAvailable = true },
                new Vehicle { Id = 6, CategoryId = 1, Name = "Mercedes", ModelSku = "AWMUTV", Price = 7463595, IsAvailable = true },
                new Vehicle { Id = 7, CategoryId = 1, Name = "Mini", ModelSku = "AWMVNP", Price = 2454565, IsAvailable = true },
                new Vehicle { Id = 8, CategoryId = 1, Name = "Tesla", ModelSku = "AWMVNS", Price = 245265, IsAvailable = true },
                new Vehicle { Id = 9, CategoryId = 1, Name = "Opel", ModelSku = "AWMVNT", Price = 245217, IsAvailable = true },
                new Vehicle { Id = 10, CategoryId = 2, Name = "Opel", ModelSku = "AWWBTSC", Price = 254299, IsAvailable = true },
                new Vehicle { Id = 11, CategoryId = 2, Name = "Mercedes", ModelSku = "AWWCTT", Price = 24520, IsAvailable = false },
                new Vehicle { Id = 12, CategoryId = 2, Name = "BMW", ModelSku = "AWWGSJ", Price = 254268, IsAvailable = true },
                new Vehicle { Id = 13, CategoryId = 2, Name = "Mini", ModelSku = "AWWSJ", Price = 2452125, IsAvailable = true },
                new Vehicle { Id = 14, CategoryId = 2, Name = "BMW", ModelSku = "AWWSDP", Price = 52455, IsAvailable = true },
                new Vehicle { Id = 15, CategoryId = 2, Name = "BMW", ModelSku = "AWWUTT", Price = 224522, IsAvailable = true },
                new Vehicle { Id = 16, CategoryId = 2, Name = "Opel", ModelSku = "AWWUTV", Price = 92455, IsAvailable = true },
                new Vehicle { Id = 17, CategoryId = 2, Name = "Audi", ModelSku = "AWWVNT", Price = 125427, IsAvailable = true },
                new Vehicle { Id = 18, CategoryId = 3, Name = "Mercedes", ModelSku = "MWB", Price = 2.8M, IsAvailable = true },
                new Vehicle { Id = 19, CategoryId = 3, Name = "Skoda", ModelSku = "MWLL", Price = 2.8M, IsAvailable = true },
                new Vehicle { Id = 20, CategoryId = 3, Name = "Mercedes", ModelSku = "MWO", Price = 2.8M, IsAvailable = true });
        }
    }
}