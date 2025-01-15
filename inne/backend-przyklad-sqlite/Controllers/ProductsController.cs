using backend_przyklad_sqlite.Data;
using backend_przyklad_sqlite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_przyklad_sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Konstruktor kontrolera przyjmujący kontekst bazy danych
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/products - Pobiera listę wszystkich produktów
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/products/1 - Pobiera pojedynczy produkt po jego id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(); // Zwrócenie błędu 404, jeśli produkt nie zostanie znaleziony
            }
            return product;
        }

        // POST: api/products - Tworzy nowy produkt
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            _context.Products.Add(product); // Dodanie produktu do bazy
            await _context.SaveChangesAsync(); // Zapisanie zmian w bazie

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product); // Zwrócenie utworzonego produktu
        }

        // PUT: api/products/1 - Aktualizuje produkt o podanym id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest(); // Zwrócenie błędu 400, jeśli id się nie zgadza
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); // Zapisanie zmian w bazie
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id)) // Sprawdzenie, czy produkt istnieje
                {
                    return NotFound(); // Zwrócenie błędu 404, jeśli produkt nie istnieje
                }
                throw; // Inny błąd aktualizacji
            }

            return NoContent(); // Zwrócenie odpowiedzi 204 - brak treści
        }

        // DELETE: api/products/1 - Usuwa produkt o podanym id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id); // Wyszukiwanie produktu po id
            if (product == null)
            {
                return NotFound(); // Zwrócenie błędu 404, jeśli produkt nie zostanie znaleziony
            }

            _context.Products.Remove(product); // Usunięcie produktu z bazy
            await _context.SaveChangesAsync(); // Zapisanie zmian w bazie

            return NoContent(); // Zwrócenie odpowiedzi 204 - brak treści
        }

        // Sprawdzanie, czy produkt o danym id istnieje
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
