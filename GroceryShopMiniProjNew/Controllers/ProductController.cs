using GroceryShopMiniProjNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShopMiniProjNew.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDBContext _db;
        public ProductController(ProductDBContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult product()
        {
            var Getrecords = _db.GroceryProducts.ToList();
            List<GroceryProduct> prod = new List<GroceryProduct>();
            foreach (var item in Getrecords)
            {
                var ProductItems = new GroceryProduct()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductPrice = item.ProductPrice,
                    ProductQuantityKg = item.ProductQuantityKg
                };
                prod.Add(ProductItems);


            };
            return View(prod);


        }
    }
}
