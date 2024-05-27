using KhumaloCrafts.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCrafts.Controllers
{
    public class ProductController : Controller
    {
        public ProductTable prod = new ProductTable();

        [HttpPost]
        public ActionResult MyWork(ProductTable products)
        {
            if (!ModelState.IsValid)
            {
                return View(prod);
            }
            var result2 = prod.insert_product(products);
            return RedirectToAction("Index", "Home");
        }

        // Get: display the form for adding a new product
        [HttpGet]
        public ActionResult MyWork()
        {
            return View(prod);
        }
    }
}
