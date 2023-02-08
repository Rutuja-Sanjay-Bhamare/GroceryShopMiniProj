using GroceryShopMiniProjNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroceryShopMiniProjNew.Controllers
{
    public class EditController : Controller
    {

        private readonly ProductDBContext _db;
        public EditController(ProductDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<GroceryProduct> products = _db.GroceryProducts.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(GroceryProduct prod)
        {
            if (ModelState.IsValid)
            {


                _db.GroceryProducts.Add(prod);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(prod);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            GroceryProduct prod = _db.GroceryProducts.Single(x => x.ProductId == id);
            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(GroceryProduct prod)
        {
            if (ModelState.IsValid)
            {


                _db.Entry(prod).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(prod);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            GroceryProduct prod = _db.GroceryProducts.Single(x => x.ProductId == id);

            return View(prod);
        }
        [HttpPost]
        [ActionName("Delete")]

        public IActionResult Deleteconfirm(int id)
        {



            GroceryProduct prod = _db.GroceryProducts.Single(x => x.ProductId == id);

            _db.GroceryProducts.Remove(prod);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            GroceryProduct prod = new GroceryProduct();
            prod = _db.GroceryProducts.Single(x => x.ProductId == id);
            return View(prod);
        }
    }
}
