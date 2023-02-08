using GroceryShopMiniProjNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShopMiniProjNew.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            LoginPage loginPage = new LoginPage();

            return View(loginPage);
            //  return View();
        }




        [HttpPost]

        public IActionResult Login(LoginPage loginPage)
        {
            ProductDBContext prod = new ProductDBContext();

            var status = prod.LoginPages.Where(m => m.Username == loginPage.Username && m.Pasword == loginPage.Pasword).FirstOrDefault();

            if (status != null)

            {

                ViewBag.Message = "Success full login";
                HttpContext.Session.SetString("username", loginPage.Username);

                return RedirectToAction("Index", "Edit");

            }

            else

            {

                ViewBag.Message = "Invalid login detail.";

            }

            return View(loginPage);
        }
    }
}
