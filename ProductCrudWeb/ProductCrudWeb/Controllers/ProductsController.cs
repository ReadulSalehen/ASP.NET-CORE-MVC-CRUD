using Microsoft.AspNetCore.Mvc;
using ProductCrudWeb.DB;
using ProductCrudWeb.Models;

namespace ProductCrudWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Product pro)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(pro);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pro);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product? pro = _context.Products.SingleOrDefault(p => p.Id == id);
            if(pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }

        [HttpPost]

        public IActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product? pro = _context.Products.SingleOrDefault(p => p.Id == id);
            if (pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }

        [HttpPost]

        public IActionResult Delete(Product model)
        {
            Product? pro = _context.Products.SingleOrDefault(p => p.Id == model.Id);
            if (pro == null)
            {
                return NotFound();
            }
            _context.Products.Remove(pro);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
