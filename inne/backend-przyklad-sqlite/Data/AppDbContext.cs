using backend_przyklad_sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_przyklad_sqlite.Data
{
    public class AppDbContext : DbContext
    {
        // Konstruktor klasy kontekstu, przyjmujący opcje konfiguracji
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        // Zestaw produktów w bazie danych
        public DbSet<Product> Products { get; set; }

        // Inicjalizacja danych w bazie (Seed)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Dodanie początkowych danych do tabeli Product
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 2999.99m },
                new Product { Id = 2, Name = "Smartphone", Price = 999.99m },
                new Product { Id = 3, Name = "Headphones", Price = 199.99m }
            );
        }
    }
}
