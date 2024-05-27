using KhumaloCrafts.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCrafts.Controllers
{
    public class ProductDisplayController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }
    }
}
