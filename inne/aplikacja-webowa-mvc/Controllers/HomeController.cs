using aplikacja_webowa_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aplikacja_webowa_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 2999.99m },
            new Product { Id = 2, Name = "Smartphone", Price = 999.99m },
            new Product { Id = 3, Name = "Headphones", Price = 199.99m }
        };

        // Create some sample data or fetch from a database
        public IActionResult Index()
        {
            // Sample data (replace this with actual database call or service)
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.99M },
                new Product { Id = 2, Name = "Product 2", Price = 20.99M },
                new Product { Id = 3, Name = "Product 3", Price = 30.99M }
            };

            return View(products);  // Pass the products list to the view
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        // GET: Product/Details/{id}
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
                _products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/{id}
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Price")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingProduct = _products.FirstOrDefault(p => p.Id == id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Delete/{id}
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
