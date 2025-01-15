using System.ComponentModel.DataAnnotations;

namespace backend_przyklad_sqlite.Models
{
    public class Product
    {
        // Identyfikator produktu
        public int Id { get; set; }

        // Nazwa produktu (wymagane pole)
        [Required]
        public string Name { get; set; } = string.Empty;

        // Cena produktu (wymagane pole)
        [Required]
        public decimal Price { get; set; }
    }
}
