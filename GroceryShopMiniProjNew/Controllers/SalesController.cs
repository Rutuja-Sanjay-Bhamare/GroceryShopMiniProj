using GroceryShopMiniProjNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroceryShopMiniProjNew.Controllers
{
    public class SalesController : Controller
    {
        [HttpGet]
        public IActionResult sales()
        {
            Sale sale = new Sale();

            ProductDBContext productDBContext = new ProductDBContext();

            ViewBag.ProductNavigation = new SelectList(productDBContext.GroceryProducts.ToList(), "ProductId", "ProductName");

            return View(sale);

        }
        [HttpPost]
        public IActionResult sales(Sale sale)

        {
            ProductDBContext productDBContext = new ProductDBContext();

            productDBContext.Add(sale);
            productDBContext.SaveChanges();



            ViewBag.Message = "Product recept generated";




            ViewBag.ProductNavigation = new SelectList(productDBContext.GroceryProducts.ToList(), "ProductId", "ProductName");

            return View(sale);

        }
        [HttpGet]
        public IActionResult Getdata(int ProductId)
        {
            ProductDBContext productDBContext = new ProductDBContext();
            var productPrice = productDBContext.GroceryProducts.Where(x => x.ProductId == ProductId).Select(x => x.ProductPrice).FirstOrDefault();
            return Json(productPrice);
        }



    }
}
