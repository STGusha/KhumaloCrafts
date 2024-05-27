using KhumaloCrafts.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCrafts.Controllers
{
    public class UserController : Controller
    {
        public UserTable usrtbl = new UserTable();


        [HttpPost]
        public ActionResult About(UserTable Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("Privacy", "Home");
        }

        [HttpGet]
        public ActionResult About()
        {
            return View(usrtbl);
        }

    }
}
